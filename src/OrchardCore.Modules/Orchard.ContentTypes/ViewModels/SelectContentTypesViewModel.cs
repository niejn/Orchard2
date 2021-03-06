﻿using System.Linq;
using Orchard.ContentManagement.Metadata.Models;
using Orchard.ContentManagement.MetaData;

namespace Orchard.ContentTypes.ViewModels
{
    public class SelectContentTypesViewModel
    {
        public string HtmlName { get; set; }
        public ContentTypeSelection[] ContentTypeSelections { get; set; }
    }

    public class ContentTypeSelection
    {
        public bool IsSelected { get; set; }
        public ContentTypeDefinition ContentTypeDefinition { get; set; }

        public static ContentTypeSelection[] Build(IContentDefinitionManager contentDefinitionManager, string[] selectedContentTypes)
        {
            var contentTypes = contentDefinitionManager
                .ListTypeDefinitions()
                .Select(x =>
                    new ContentTypeSelection
                    {
                        IsSelected = selectedContentTypes.Contains(x.Name),
                        ContentTypeDefinition = x
                    })
                .OrderBy(type => type.ContentTypeDefinition.DisplayName)
                .ToArray();

            return contentTypes;
        }
    }
}
