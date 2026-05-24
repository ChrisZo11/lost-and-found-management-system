using System;
using System.Collections.Generic;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;

namespace LostAndFound
{
    public interface ICameraController : IDisposable
    {
        event EventHandler<CameraFrameEventArgs> FrameReady;
        int DeviceCount { get; }
        bool HasDevices { get; }
        IList<string> LoadDeviceNames();
        void Start(int deviceIndex);
        void Stop();
    }

    public sealed class CameraFrameEventArgs : EventArgs
    {
        public CameraFrameEventArgs(Bitmap frame)
        {
            Frame = frame;
        }

        public Bitmap Frame { get; private set; }
    }

    public sealed class CameraController : ICameraController
    {
        private FilterInfoCollection devices;
        private VideoCaptureDevice videoSource;

        public event EventHandler<CameraFrameEventArgs> FrameReady;

        public int DeviceCount
        {
            get { return devices == null ? 0 : devices.Count; }
        }

        public bool HasDevices
        {
            get { return DeviceCount > 0; }
        }

        public IList<string> LoadDeviceNames()
        {
            devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            List<string> names = new List<string>();

            foreach (FilterInfo device in devices)
            {
                names.Add(device.Name);
            }

            return names;
        }

        public void Start(int deviceIndex)
        {
            if (devices == null || devices.Count == 0)
            {
                throw new InvalidOperationException("Perangkat kamera tidak ditemukan.");
            }

            if (deviceIndex < 0 || deviceIndex >= devices.Count)
            {
                throw new InvalidOperationException("Pilih kamera terlebih dahulu.");
            }

            Stop();
            videoSource = new VideoCaptureDevice(devices[deviceIndex].MonikerString);
            videoSource.NewFrame += videoSource_NewFrame;
            videoSource.Start();
        }

        public void Stop()
        {
            if (videoSource == null)
            {
                return;
            }

            VideoCaptureDevice activeSource = videoSource;
            videoSource = null;
            activeSource.NewFrame -= videoSource_NewFrame;

            if (activeSource.IsRunning)
            {
                activeSource.SignalToStop();
                activeSource.WaitForStop();
            }
        }

        public void Dispose()
        {
            Stop();
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            EventHandler<CameraFrameEventArgs> handler = FrameReady;
            if (handler == null)
            {
                return;
            }

            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            try
            {
                handler(this, new CameraFrameEventArgs(frame));
            }
            catch
            {
                frame.Dispose();
            }
        }
    }
}
