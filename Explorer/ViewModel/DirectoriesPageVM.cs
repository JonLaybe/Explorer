using Explorer.Model;
using Explorer.Model.Directories;
using Explorer.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Explorer.ViewModel
{
    public class DirectoriesPageVM : ViewModelBase
    {
        private Disk _selectedDisk; // выбранный диск
        private ObjectDirectorie _selectedObject; // выбранный объект в каталоге
        private Dir _selectedDir;
        private bool _isOpenPopupSettings;
        private NavigationPage _navigationPage;
        private GetInfo _getInfo;
        private ActionsInDir _actionsInDir;
        private bool _isOpenWin;

        public DirectoriesPageVM()
        {
            _navigationPage = NavigationPage.GetNavigationPage();
            SelectedDisk = (Disk)_navigationPage.Parameter;
            _getInfo = new GetInfo();
            _actionsInDir = new ActionsInDir();
            SelectedDir = _getInfo.GetDir(SelectedDisk.Name);
            IsOpenPopupSettings = false;
            IsOpenWin = "Hidden";
        }

        private void RefreshDir()
        {
            if (_selectedDir != null)
                SelectedDir = _getInfo.GetDir(_selectedDir.NameDir);
        }

        public Disk SelectedDisk
        {
            get { return _selectedDisk; }
            set
            {
                _selectedDisk = value;
                Notify(nameof(SelectedDisk));
            }
        }

        public Dir SelectedDir
        {
            get { return _selectedDir; }
            set
            {
                _selectedDir = value;
                Notify(nameof(SelectedDir));
            }
        }

        public ObjectDirectorie SelectedObject
        {
            get { return _selectedObject; }
            set
            {
                _selectedObject = value;
                Notify(nameof(SelectedObject));
            }
        }

        public bool IsOpenPopupSettings
        {
            get { return _isOpenPopupSettings; }
            set
            {
                _isOpenPopupSettings = value;
                Notify(nameof(IsOpenPopupSettings));
            }
        }

        public string IsOpenWin
        {
            get { return _isOpenWin ? "Visible" : "Hidden"; }
            set
            {
                if (value == "Visible")
                    _isOpenWin = true;
                else if (value == "Hidden")
                    _isOpenWin = false;
                Notify(nameof(IsOpenWin));
            }
        }

        public ButtonCommand ObjectSettingsOpenBtn
        {
            get
            {
                return new ButtonCommand((object obj) =>
                {
                    IsOpenPopupSettings = true;
                });
            }
        }

        public ButtonCommand ObjectSettingsCloseBtn
        {
            get
            {
                return new ButtonCommand((object obj) =>
                {
                    IsOpenPopupSettings = false;
                });
            }
        }

        public ButtonCommand OpenFolderBtn // открытие папки
        {
            get
            {
                return new ButtonCommand((object obj) =>
                {
                    try
                    {
                        IsOpenPopupSettings = false;
                        if (_selectedObject != null && _selectedObject.Type == "Folder")
                        {
                            SelectedDir = _getInfo.GetDir($"{_selectedDir.NameDir}\\{_selectedObject.Name}");
                        }
                        else if (_selectedObject != null && _selectedObject.Type == "File")
                        {
                            Task.Run(() =>
                            {
                                var proc = new System.Diagnostics.Process();
                                proc.StartInfo.FileName = $"{_selectedDir.NameDir}\\{_selectedObject.Name}";
                                proc.StartInfo.UseShellExecute = true;
                                proc.Start();
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }

        public ButtonCommand RenameObjectBtn // переименование
        {
            get
            {
                return new ButtonCommand((object obj) =>
                {
                    try
                    {
                        IsOpenPopupSettings = false;
                        if (_selectedObject != null) { }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }

        public ButtonCommand DeleteObjectBtn
        {
            get
            {
                return new ButtonCommand((object obj) =>
                {
                    try
                    {
                        IsOpenPopupSettings = false;
                        if (_selectedObject != null)
                        {
                            //IsOpenWin = "Visible";
                            _actionsInDir.DeleteObject($"{_selectedDir.NameDir}\\{_selectedObject.Name}", _selectedObject.Type);
                            RefreshDir();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }
    }
}
