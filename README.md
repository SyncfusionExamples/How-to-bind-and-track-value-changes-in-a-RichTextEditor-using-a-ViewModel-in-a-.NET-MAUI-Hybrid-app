This article demonstrates how to bind content to the [Blazor RichTextEditor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) in a .NET MAUI Hybrid application using a ViewModel. The approach ensures that any changes in the editor are reflected in the ViewModel, and those changes can be tracked and displayed within the `.NET MAUI UI`.

**ViewModel Implementation**

To begin, create a ViewModel (e.g., `ViewModel.cs`) that implements `INotifyPropertyChanged`. This will allow the UI to respond to changes in the data model.

```csharp
public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string text = "<a href='https://www.google.com/'>Google!</a>";
    public string Text 
    {
        get { return text; }
        set { text = value; OnPropertyChanged("Text"); }
    }
}
```

To complete the setup, ensure the `ViewModel` is registered with the dependency injection container in the `.NET MAUI` application. This can be done in the `MauiProgram.cs` file:

```csharp
...
builder.Services.AddSingleton<ViewModel>();
...
```

This registration allows the `ViewModel` to be injected into both the Blazor components and the .NET MAUI pages.

**Blazor RichTextEditor Integration**

In your Blazor component (e.g., `Home.razor`), you can bind the RichTextEditor to the ViewModel's Text property. The following code snippet demonstrates this:

```razor
@page "/"
@using Syncfusion.Blazor.RichTextEditor
@using System.ComponentModel
@implements IDisposable
@inject ViewModel ViewModel

<SfRichTextEditor @bind-Value="ViewModel.Text" SaveInterval="1">
</SfRichTextEditor>

@code {
    protected override void OnInitialized()
    {
        base.OnInitialized();
        ViewModel.PropertyChanged += OnValueChanged;
    }

    private void OnValueChanged(object sender, PropertyChangedEventArgs e)
    {
        StateHasChanged();
    }

    public void Dispose()
    {
        ViewModel.PropertyChanged -= OnValueChanged;
    }
}
```

In this code:

- The `ViewModel` is injected into the Blazor component using `@inject ViewModel ViewModel`.
- The `SfRichTextEditor` binds directly to the `Text` property of the `ViewModel` through the `@bind-Value` directive, enabling two-way data binding.
- The `OnValueChanged` method updates the UI when the `Text` property in the `ViewModel` changes.
- The `Dispose` method removes the event handler to prevent memory leaks.

**MAUI Label Binding**

To display the content of the RichTextEditor in a MAUI Label, you can refer to the below code:

**XAML:**
```xml
<Label Text="{Binding Text}" TextType="Html" TextColor="Black" Margin="5" VerticalOptions="Center"/>
```

**C#:**
```csharp
public partial class MainPage : ContentPage
{
    public MainPage(ViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel;
    }
}
```

**Output**

![RichTextEditor.png](https://support.syncfusion.com/kb/agent/attachment/article/17109/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI4MTk5Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.7L4aGHuSSBIrh6LKfuQAXA6lKWbS85xx2DOJK746g_A)
