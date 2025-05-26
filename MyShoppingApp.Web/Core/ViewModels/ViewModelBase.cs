using MyShoppingApp.Shared;

namespace MyShoppingApp.Web.Core.ViewModels;

public abstract class ViewModelBase
{
    public Action StateHasChanged { get; set; } = () => { };
    public Action<string> ToastOk { get; internal set; } = (s) => { };
    public Action<string> ToastInfo { get; internal set; } = (s) => { };
    public Action<string> ToastSuccess { get; internal set; } = (s) => { };
    public Action<string> ToastWarn { get; internal set; } = (s) => { };
    public Action<string> ToastError { get; internal set; } = (s) => { };
    public bool IsBusy { get; set; }
    public string? ErrorMessage { get; set; }

    public virtual Task OnInitializedAsync()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnParametersSetAsync()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnAfterRenderAsync(bool firstRender)
    {
        return Task.CompletedTask;
    }

    protected void ToastServiceFailureException(ServiceFailureException ex)
    {
        switch (ex.Severity)
        {
            case ServiceFailureSeverity.Error:
                ToastError?.Invoke(ex.Message);
                break;
            case ServiceFailureSeverity.Warning:
                ToastWarn?.Invoke(ex.Message);
                break;
            default:
                ToastInfo?.Invoke(ex.Message);
                break;
        }
    }
}
