using System;
using UnityEngine;
using System.IO.Ports;

public class ArduinoCommunication : MonoBehaviour
{
    public string portName = "COM4"; // Ubah sesuai dengan port yang digunakan
    public int baudRate = 9600;
    private SerialPort serialPort;

    private void Start()
    {
        serialPort = new SerialPort(portName, baudRate);
        serialPort.DtrEnable = true; // Mengaktifkan pin DTR
        serialPort.RtsEnable = true; // Mengaktifkan pin RTS
        serialPort.Open();
        serialPort.ReadTimeout = 100;
    }

    private void Update()
    {
        try
        {
            string message = serialPort.ReadLine();
            UnityEngine.Debug.Log("Received message: " + message);

            if (message.Contains("Button Pressed"))
            {
                UnityEngine.Debug.Log("Button Pressed");
                // Tambahkan kode yang ingin dijalankan saat tombol ditekan
            }
            else if (message.Contains("Button Released"))
            {
                UnityEngine.Debug.Log("Button Released");
                // Tambahkan kode yang ingin dijalankan saat tombol dilepas
            }
        }
        catch (TimeoutException)
        {
            // TimeoutException dapat diabaikan, tidak ada data yang diterima dari Arduino
        }
    }

    private void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}