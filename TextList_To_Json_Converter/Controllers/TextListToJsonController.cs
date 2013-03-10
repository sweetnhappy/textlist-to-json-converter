using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using TextList_To_Json_Converter.Models;

namespace TextList_To_Json_Converter.Controllers
{
    public class TextListToJsonController : Controller
    {
        //
        // GET: /TextListToJson/

        [HttpGet]
        public ActionResult Index()
        {
            return View(new ConverterData());
        }

        //
        // POST: /TextListToJson/Process

        [HttpPost]
        public ActionResult Process(ConverterData data)
        {
            if (data.GroupCount <= 0)
            {
                data.GroupCount = 0;

                data.GroupNames = null;
                data.GroupItemBlobs = null;
            }

            if (data.GroupCount > 0 && data.GroupNames == null)
            {
                data.GroupNames = new string[data.GroupCount];
                data.GroupItemBlobs = new string[data.GroupCount];
            }

            if (data.GroupNames != null)
            {
                data.Collection.Groups = new List<LineItemsCollection.Group>();

                for (var i = 0; i < data.GroupNames.Length; i++)
                {
                    data.Collection.Groups.Add(
                        new LineItemsCollection.Group()
                            {
                                GroupId = i,
                                Name = data.GroupNames[i]
                            });
                }
            }

            if (data.GroupItemBlobs != null)
            {
                data.Collection.Items = new List<LineItemsCollection.Item>();

                for (var i = 0; i < data.GroupItemBlobs.Length; i++)
                {
                    if (!String.IsNullOrWhiteSpace(data.GroupItemBlobs[i]))
                    {
                        var groupItems = data.GroupItemBlobs[i].Split(
                            new string[] {data.GroupItemDelimiter}, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var groupItem in groupItems)
                        {
                            var trimmedItem = groupItem.Trim();

                            data.Collection.Items.Add(
                                new LineItemsCollection.Item()
                                    {
                                        Content = trimmedItem,
                                        ParentGroupId = i
                                    });
                        }
                    }
                }
            }

            if (data.Collection.Groups.Any() && data.Collection.Items.Any())
            {
                var jsonSerializer = new JsonSerializer();
                var stringBuilder = new StringBuilder();

                using (var jsonTextWriter = new JsonTextWriter(new StringWriter(stringBuilder)))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.Indentation = 4;
                    jsonSerializer.Serialize(jsonTextWriter, data.Collection);
                }

                data.Output = stringBuilder.ToString();
            }

            return View("Index", data);
        }
    }
}