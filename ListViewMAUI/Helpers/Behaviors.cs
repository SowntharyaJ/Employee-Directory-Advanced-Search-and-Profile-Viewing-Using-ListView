using Syncfusion.Maui.DataSource;
using System.ComponentModel;

#nullable disable

namespace ListViewMAUI
{
    #region Behavior
    public class SfListViewFilteringBehavior : Behavior<ContentPage>
    {
        #region Fields

        private Syncfusion.Maui.ListView.SfListView ListView;
        private EmployeeDirectoryViewModel viewModel;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = ListView = bindable.FindByName<Syncfusion.Maui.ListView.SfListView>("listView");   
            viewModel = bindable.BindingContext as EmployeeDirectoryViewModel;
            viewModel.PropertyChanged += OnPropertyChanged;
            base.OnAttachedTo(bindable);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ListView.DataSource != null)
            {
                switch (e.PropertyName)
                {
                    case nameof(EmployeeDirectoryViewModel.SearchText):
                    case nameof(EmployeeDirectoryViewModel.SelectedDepartment):
                    case nameof(EmployeeDirectoryViewModel.SelectedSkill):
                        ListView.DataSource.Filter = viewModel.OnPerformSearch;
                        break;
                }
                ListView.DataSource.RefreshFilter();
                ListView.RefreshView();
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            viewModel.PropertyChanged -= OnPropertyChanged;
            ListView = null;
            viewModel = null;            
            base.OnDetachingFrom(bindable);
        }  

        #endregion
    }
    #endregion
}
