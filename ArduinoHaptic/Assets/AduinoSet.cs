using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;
using TMPro;


public class AduinoSet : MonoBehaviour
{
    

    public enum PortNumber
    {
        COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, COM10, COM11, COM12, COM13, COM14, COM15, COM16
    }
   int[] pressure = new int[1];      // 압력 값 변수 5
    //int pressure;
    SerialPort serial = new SerialPort("COM5", 9600);

    /// <summary>
    /// 텍스트 출력용 코드
    /// </summary>
    string fullpth = "Assets/Resources/DataSave";
    StreamWriter sw;


    [SerializeField]
   public TextMeshProUGUI text1;  // 점수 출력
    /*
    [SerializeField]
    public TextMeshProUGUI text2;  // 점수 출력
    [SerializeField]
    public TextMeshProUGUI text3;  // 점수 출력
    [SerializeField]
    public TextMeshProUGUI text4;  // 점수 출력
    [SerializeField]
    public TextMeshProUGUI text5;  // 점수 출력 
    */
    void Start()
    {
        serial.Open();
        serial.ReadTimeout = 1;

        /// TXT 파일 출력 준비, 파일이 존재하지 않을 경우 생성
        if (false == File.Exists(fullpth))
        {
            sw = new StreamWriter(fullpth + ".txt");
        }


        /// 1초마다 TXT 파일 출력 코루틴
        StartCoroutine(textOut(1));
    }

    void Update()
    {
        
    }


    IEnumerator textOut(float delayTime)
    {
        

        if (serial.IsOpen)
        {
            try
            {

                for (int i = 0; i <= 0; i++)
                {
                     pressure[i] = serial.ReadByte();
                     Debug.Log(pressure[i]);                 // 값 읽고 로그 찍기
                   // pressure= serial.ReadByte();
                     //Debug.Log(pressure);            
                }
               // Debug.Log(",");

                

/*
                sw.WriteLine(pressure[0] + ", " + pressure[1] + ", " + pressure[2] + ", " + pressure[3] + ", " + pressure[4] );
                // ㅡ,ㅡ,ㅡ,ㅡ,ㅡ 의 형태로 텍스트 출력하게 함
                text1.text = " 1st : " + pressure[0];
                text2.text = " 2nd : " + pressure[1];
                text3.text = " 3rd : " + pressure[2];
                text4.text = " 4th : " + pressure[3];
                text5.text = " 5th : " + pressure[4];
                sw.Flush();

                */

            }

            catch (System.Exception)
            {

            }

        }

        

        /// 1초 마다 작동
        yield return new WaitForSeconds(delayTime);
         StartCoroutine(textOut(1));


    }

}
