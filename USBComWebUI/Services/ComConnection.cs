using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace USBComWebUI.Components.Services
{
    public class ComConnection
    {
        public SerialPort serCOM;

        // Define a delegate for the callback
        public delegate void DataReceivedHandler(string data);
        public event DataReceivedHandler OnDataReceived;

        public ComConnection()
        {
            this.serCOM = new SerialPort();
            serCOM.DataReceived += OnReceived; // Attach internal event handler
        }

        public Boolean OnConn(string portName, int baudRate = 9600)
        {
            if (IsConnected())
            {
                Console.WriteLine("Port is already open.");
                return true;
            }

            try
            {
                serCOM.PortName = portName;
                serCOM.BaudRate = baudRate;
                serCOM.Parity = Parity.None;
                serCOM.DataBits = 8;
                serCOM.StopBits = StopBits.One;
                serCOM.Handshake = Handshake.None;

                serCOM.Open();
                Console.WriteLine($"Connected to {portName} at {baudRate} baud.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to {portName}: {ex.Message}");
                return false;
            }
        }

        public void Send(string data)
        {
            if (IsConnected())
            {
                try
                {
                    serCOM.WriteLine(data);
                    Console.WriteLine($"Sent: {data}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending data: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Port is not open. Cannot send data.");
            }
        }

        private void OnReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string receivedData = serCOM.ReadLine();
                if (receivedData.Trim().Length > 0)
                {
                    OnDataReceived?.Invoke(receivedData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving data: {ex.Message}");
            }
        }

        public void OnDisconnect()
        {
            if (IsConnected())
            {
                try
                {
                    serCOM.Close();
                    Console.WriteLine("Disconnected from the serial port.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error disconnecting: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Port is not open. Nothing to disconnect.");
            }
        }

        public List<string> GetAllPorts()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                Console.WriteLine("Available COM ports:");

                List<string> portList = ports.ToList();

                foreach (string port in portList)
                {
                    Console.WriteLine(port);
                }

                return portList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving COM ports: {ex.Message}");
                return new List<string>();
            }
        }

        public Boolean IsConnected()
        {
            return serCOM != null && serCOM.IsOpen;
        }
    }
}
