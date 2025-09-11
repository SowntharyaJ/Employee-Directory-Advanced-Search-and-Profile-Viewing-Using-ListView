using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ListViewMAUI
{
    public class EmployeeDirectoryViewModel : INotifyPropertyChanged
    {
        // IsOpen property for open/close popup
        private bool isOpenForSearch;   

        private ObservableCollection<Employee> _employees = new();        
        private string _searchText = string.Empty;
        private string _selectedDepartment = string.Empty;
        private string _selectedSkill = string.Empty;
        private Employee? _selectedEmployee;
        private EmployeeDirectoryRepository repository;        


        public EmployeeDirectoryViewModel()
        {
            repository = new EmployeeDirectoryRepository();
            LoadEmployees();            
            ClearFiltersCommand = new Command(OnClearFilters);
            ViewProfileCommand = new Command<object>(OnViewProfile);
            SearchAndFilter = new Command(OnSearchAndFilter);
        }

        public ObservableCollection<Employee> EmployeeDirectories
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        public string SelectedDepartment
        {
            get => _selectedDepartment;
            set
            {
                _selectedDepartment = value;
                OnPropertyChanged();                
            }
        }

        public string SelectedSkill
        {
            get => _selectedSkill;
            set
            {
                _selectedSkill = value;
                OnPropertyChanged();                
            }
        }

        public Employee? SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        public List<string> Departments { get; set; } = new();
        public List<string> Skills { get; set; } = new();        
        public ICommand ClearFiltersCommand { get; }
        public ICommand ViewProfileCommand { get; }
        public ICommand SearchAndFilter { get; }

        public bool IsOpenForSearch
        {
            get
            {
                return isOpenForSearch;
            }
            set
            {
                isOpenForSearch = value;
                OnPropertyChanged(nameof(IsOpenForSearch));
            }
        }  

        private void OnSearchAndFilter()
        {
            IsOpenForSearch = true;
        }
        private void LoadEmployees()
        {
            EmployeeDirectories = repository.GetEmployees();                        
            Departments = repository.GetDepartments();
            Skills = repository.GetSkills();
        }

        internal bool OnPerformSearch(object obj)
        {
            var employee = obj as Employee;
            if (employee == null)
                return false;

            // Match for SearchText filter (true if filter is empty or if it matches)
            bool searchTextMatch = string.IsNullOrWhiteSpace(SearchText) ||
                                   employee.FullName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                   employee.Email.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                   employee.Position.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                   employee.Department.Contains(SearchText, StringComparison.OrdinalIgnoreCase);

            // Match for Department filter (true if filter is empty or if it matches)
            bool departmentMatch = string.IsNullOrWhiteSpace(SelectedDepartment) ||
                                   employee.Department.Equals(SelectedDepartment, StringComparison.OrdinalIgnoreCase);

            // Match for Skill filter (true if filter is empty or if it matches)
            bool skillMatch = string.IsNullOrWhiteSpace(SelectedSkill) ||
                              (employee.Skills != null && employee.Skills.Any(s => s.Contains(SelectedSkill, StringComparison.OrdinalIgnoreCase)));

            // The employee is a match only if they meet all the active filter criteria
            return searchTextMatch && departmentMatch && skillMatch;
        }

        private void OnClearFilters()
        {
            SearchText = string.Empty;
            SelectedDepartment = string.Empty;
            SelectedSkill = string.Empty;
            IsOpenForSearch = false;
        }

        private async void OnViewProfile(object eventArgs)
        {
            var data = eventArgs as Syncfusion.Maui.ListView.ItemTappedEventArgs;
            var employee = data.DataItem as Employee;
            SelectedEmployee = employee;    
            if (employee != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new EmployeeProfilePage() { BindingContext = this});
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}