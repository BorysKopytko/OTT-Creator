﻿using OTTCreator.Client.Pages;
using OTTCreator.Client.Services;

namespace OTTCreator.Client;

public partial class AppShell : Shell
{
    ContentService contentService;

    public AppShell()
    {
        InitializeComponent();

        contentService = new ContentService();
        var task = Task.Run(GenerateUI);
        task.Wait();

        RegisterRoutes();
    }

    private async Task GenerateUI()
    {
        var types = await contentService.GetTypesAsync();

        var categoryPageDataTemplate = new DataTemplate(typeof(CategoryPage));

        foreach (var type in types)
            FavoriteContentFlyoutItem.Items.Add(new ShellContent() { Title = type, ContentTemplate = categoryPageDataTemplate });

        foreach (var type in types)
        {
            var UIType = new FlyoutItem() { Title = type };
            if (type == "Телеканали")
                UIType.Icon = "tv_icon.png";
            else if (type == "Радіостанції")
                UIType.Icon = "radio_icon.png";
            var categories = await contentService.GetCategoriesAsync(type);
            foreach (var category in categories)
                UIType.Items.Add(new ShellContent() { Title = category, ContentTemplate = categoryPageDataTemplate });
            Shell.Items.Add(UIType);
        }
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute("ContentItemPage", typeof(ContentItemPage));
        Routing.RegisterRoute("CategoryPage", typeof(CategoryPage));
        Routing.RegisterRoute("SupportPage", typeof(SupportPage));
    }
}
