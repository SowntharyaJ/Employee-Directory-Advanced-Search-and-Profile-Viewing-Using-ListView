using System.ComponentModel;

namespace ListViewMAUI
{
    public class Employee : INotifyPropertyChanged
    {
        private int _id;
        private string _firstName;
        private string _lastName;        
        private string _email;
        private string _phone;
        private string _department;
        private string _position;
        private string[] _skills;
        private DateTime _dateOfJoining;
        private string _bio;
        private string _location;
        private string _imageUrl;
        private string _manager;
        private bool _isActive;
        private int _yearOfExperience;
        private string _bloodGroup;
        private string _emergencyPhone;
        private string _relation;
        private string _address;
        private DateTime _dob;
        private bool _isVerified;

        public int Id 
        { 
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }
                
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }
                
        public string LastName 
        { 
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }
        
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
                
        public string Email 
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }
        
        public string PhoneNumber 
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                RaisePropertyChanged(nameof(PhoneNumber));
            }
        }
                
        public string Department 
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                RaisePropertyChanged(nameof(Department));
            } 
        }
                
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                RaisePropertyChanged(nameof(Position));
            }
        }
        
        public string[] Skills
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
            }
        }
        
        public string SkillsText
        {
            get
            {
                return string.Join(", ", Skills);
            }
        }
        
        public DateTime DateOfJoining
        {
            get
            {
                return _dateOfJoining;
            }
            set
            {
                _dateOfJoining = value;
            }
        }
        
        public string Location
        {
            get
            {
                return _location;
            }
            set
            { 
                _location = value;               
                RaisePropertyChanged(nameof(Location));
            }
        }
        
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                _imageUrl = value;
                RaisePropertyChanged(nameof(ImageUrl));
            }
        }
        
        public string Bio
        {
            get
            {
                return _bio;
            }
            set
            {
                _bio = value;
                RaisePropertyChanged(nameof(Bio));
            }
        }               
        
        public string Manager
        {
            get
            {
                return _manager;
            }
            set
            {
                _manager = value;   
                RaisePropertyChanged(nameof(Manager));
            }
        }
        
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                RaisePropertyChanged(nameof(IsActive));
            }
        }
        
        public string Status
        {
            get
            {
                return IsActive ? "Active" : "Inactive";
            }
        }

        public int YearOfExperience
        {
            get
            {
                return _yearOfExperience;
            }
            set
            {
                _yearOfExperience = value;
                RaisePropertyChanged(nameof(YearOfExperience));
            }
        }
        
        public string BloodGroup
        {
            get
            {
                return _bloodGroup;
            }
            set
            {
                _bloodGroup = value;
                RaisePropertyChanged(nameof(BloodGroup));
            }
        }

        public string EmergencyPhone
        {
            get
            {
                return _emergencyPhone;
            }
            set
            {
                _emergencyPhone = value;
                RaisePropertyChanged(nameof(EmergencyPhone));
            }
        }

        public string Relation
        {
            get
            {
                return _relation;
            }
            set
            {
                _relation = value;
                RaisePropertyChanged(nameof(Relation));
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dob;
            }
            set
            {
                _dob = value;
                RaisePropertyChanged(nameof(DateOfBirth));
            }
        }

        public bool IsVerified
        {
            get
            {
                return _isVerified;
            }
            set
            {
                _isVerified = value;
                RaisePropertyChanged(nameof(IsVerified));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}