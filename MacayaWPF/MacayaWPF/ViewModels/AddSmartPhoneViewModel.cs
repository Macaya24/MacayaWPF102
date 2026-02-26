using Domain.Commands;
using Domain.Models;
using Domain.Queries;
using MacayaWPF.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MacayaWPF.ViewModels
{
    public class AddSmartPhoneViewModel : BaseViewModel
    {
        private readonly ICreateSmartPhone _createSmartPhone;
        private readonly IUpdateSmartPhone _updateSmartPhone;
        private readonly IDeleteSmartPhone _deleteSmartPhone;
        private readonly IGetAllSmartPhones _getAllSmartPhones;

        private int _smartPhoneId;
        private string _brand;
        private string _model;
        private decimal _price;
        private string _storage;
        private bool _isEditMode;
        private string _searchText;

        public ObservableCollection<SmartPhoneModel> SmartPhones { get; set; }
        public ObservableCollection<SmartPhoneModel> FilteredSmartPhones { get; set; }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }

        public int SmartPhoneId
        {
            get => _smartPhoneId;
            set { _smartPhoneId = value; OnPropertyChanged(); }
        }

        public string Brand
        {
            get => _brand;
            set { _brand = value; OnPropertyChanged(); }
        }

        public string Model
        {
            get => _model;
            set { _model = value; OnPropertyChanged(); }
        }

        public decimal Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); }
        }

        public string Storage
        {
            get => _storage;
            set { _storage = value; OnPropertyChanged(); }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set { _isEditMode = value; OnPropertyChanged(); }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterSmartPhones();
            }
        }

        public AddSmartPhoneViewModel(
            ICreateSmartPhone createSmartPhone,
            IUpdateSmartPhone updateSmartPhone,
            IDeleteSmartPhone deleteSmartPhone,
            IGetAllSmartPhones getAllSmartPhones)
        {
            _createSmartPhone = createSmartPhone;
            _updateSmartPhone = updateSmartPhone;
            _deleteSmartPhone = deleteSmartPhone;
            _getAllSmartPhones = getAllSmartPhones;

            SmartPhones = new ObservableCollection<SmartPhoneModel>();
            FilteredSmartPhones = new ObservableCollection<SmartPhoneModel>();

            AddCommand = new AddSmartPhoneCommand(this);
            UpdateCommand = new UpdateSmartPhoneCommand(this);
            DeleteCommand = new DeleteSmartPhoneCommand(this);
            EditCommand = new EditSmartPhoneCommand(this);

            _ = LoadSmartPhonesAsync();
        }

        public async Task LoadSmartPhonesAsync()
        {
            try
            {
                var smartPhones = await _getAllSmartPhones.ExecuteAsync();
                SmartPhones.Clear();
                FilteredSmartPhones.Clear();

                foreach (var smartPhone in smartPhones)
                {
                    SmartPhones.Add(smartPhone);
                    FilteredSmartPhones.Add(smartPhone);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading smartphones: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task AddSmartPhoneAsync()
        {
            try
            {
                var smartPhone = new SmartPhoneModel
                {
                    Brand = Brand,
                    Model = Model,
                    Price = Price,
                    Storage = Storage
                };

                await _createSmartPhone.ExecuteAsync(smartPhone);
                await LoadSmartPhonesAsync();
                ClearForm();
                MessageBox.Show("SmartPhone added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding smartphone: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task UpdateSmartPhoneAsync()
        {
            try
            {
                var smartPhone = new SmartPhoneModel
                {
                    SmartPhoneId = SmartPhoneId,
                    Brand = Brand,
                    Model = Model,
                    Price = Price,
                    Storage = Storage
                };

                await _updateSmartPhone.ExecuteAsync(smartPhone);
                await LoadSmartPhonesAsync();
                ClearForm();
                IsEditMode = false;
                MessageBox.Show("SmartPhone updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating smartphone: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task DeleteSmartPhoneAsync(int smartPhoneId)
        {
            try
            {
                await _deleteSmartPhone.ExecuteAsync(smartPhoneId);
                await LoadSmartPhonesAsync();
                ClearForm();
                MessageBox.Show("SmartPhone deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting smartphone: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoadSmartPhoneForEdit(SmartPhoneModel smartPhone)
        {
            SmartPhoneId = smartPhone.SmartPhoneId;
            Brand = smartPhone.Brand;
            Model = smartPhone.Model;
            Price = smartPhone.Price;
            Storage = smartPhone.Storage;
            IsEditMode = true;
        }

        private void ClearForm()
        {
            SmartPhoneId = 0;
            Brand = string.Empty;
            Model = string.Empty;
            Price = 0;
            Storage = string.Empty;
            IsEditMode = false;
        }

        private void FilterSmartPhones()
        {
            FilteredSmartPhones.Clear();

            var filtered = string.IsNullOrWhiteSpace(SearchText)
                ? SmartPhones
                : SmartPhones.Where(s =>
                    s.Brand.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    s.Model.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    s.Storage.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

            foreach (var smartPhone in filtered)
            {
                FilteredSmartPhones.Add(smartPhone);
            }
        }
    }
}
