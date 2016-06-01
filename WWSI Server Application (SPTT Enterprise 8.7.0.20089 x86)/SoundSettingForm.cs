using System;
using System.Windows.Forms;
using ClientApi;
using Common.Logging;

namespace SmartPTT_API
{
    public partial class SoundSettingForm : Form
    {
        public SoundSettingForm()
        {
            InitializeComponent();
        }

        #region Form events
        private void SoundSettingForm_Load(object sender, EventArgs e)
        {
            try
            {
                voipCaptureDevice.DataSource = ClientDispatcher.AudioController.CaptureDeviceNameList;
                if (voipCaptureDevice.Items.Count > 0)
                {
                    if (ClientDispatcher.AudioController.GetCaptureDeviceName(SoundDeviceKind.Main) == "")
                        voipCaptureDevice.SelectedIndex = 0;
                    else
                        voipCaptureDevice.SelectedItem = ClientDispatcher.AudioController.GetCaptureDeviceName(SoundDeviceKind.Main);
                }
                voipMixerInputLine.SelectedItem = ClientDispatcher.AudioController.GetInputLineName(SoundDeviceKind.Main);
                voipPlaybackDevice.DataSource = ClientDispatcher.AudioController.PlaybackDeviceNameList;
                if (voipPlaybackDevice.Items.Count > 0)
                {
                    if (ClientDispatcher.AudioController.GetPlaybackDeviceName(SoundDeviceKind.Main) == "")
                        voipPlaybackDevice.SelectedIndex = 0;
                    else
                        voipPlaybackDevice.SelectedItem = ClientDispatcher.AudioController.GetPlaybackDeviceName(SoundDeviceKind.Main);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowError(ErrorType.Error, ErrorSource.ClientLogic, ex.Message);
                butOK.Enabled = false;
            }
        }
        #endregion Form events

        #region Setting control events
        private void voipCaptureDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (voipCaptureDevice.SelectedItem != null)
            {
                try
                {
                    string devicename = voipCaptureDevice.SelectedIndex == 0 ? "" : (string)voipCaptureDevice.SelectedItem;
                    voipMixerInputLine.DataSource = ClientDispatcher.AudioController.GetInputLineNameList(devicename);
                    if (voipMixerInputLine.Items.Count > 0)
                    {
                        voipMixerInputLine.SelectedItem = ClientDispatcher.AudioController.GetMicLineName(devicename);
                        if (voipMixerInputLine.SelectedIndex < 0)
                            voipMixerInputLine.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.SaveError(ex, ErrorType.Error, ErrorSource.ClientLogic);
                }
            }
            else
                voipMixerInputLine.DataSource = null;
        }
        #endregion Setting control events

        #region Buttons
        private void butOK_Click(object sender, EventArgs e)
        {
            textError.Text = "";
            string captureDevice = "";
            if (voipCaptureDevice.SelectedIndex > 0)
                captureDevice = (string)voipCaptureDevice.SelectedItem;
            string mixerInputLine = "";
            if (voipMixerInputLine.SelectedItem != null)
                mixerInputLine = (string)voipMixerInputLine.SelectedItem;
            string playbackDevice = "";
            if (voipPlaybackDevice.SelectedIndex > 0)
                playbackDevice = (string)voipPlaybackDevice.SelectedItem;
            try
            {
                ClientDispatcher.AudioController.ApplySettings(SoundDeviceKind.Main, true, captureDevice, mixerInputLine, VoIPLib.NSMode.Off, playbackDevice);
            }
            catch (Exception ex)
            {
                ErrorHandler.SaveError(ex, ErrorType.Error, ErrorSource.ClientLogic);
                textError.Text = ex.Message;
                DialogResult = DialogResult.None;
            }
        }
        #endregion Buttons
    }
}
