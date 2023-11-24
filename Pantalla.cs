using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantalla : MonoBehaviour
{
    private Material tvMaterial;
    private WebCamTexture webcamTexture;
    private string savePath;
    int captureCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        tvMaterial = renderer.material;

        webcamTexture = new WebCamTexture();

        tvMaterial.mainTexture = webcamTexture;

        string defaultCameraName = WebCamTexture.devices[0].name;
        Debug.Log(defaultCameraName);

        savePath = Application.persistentDataPath + "/Capturas";
        System.IO.Directory.CreateDirectory(savePath);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            if (!webcamTexture.isPlaying)
            {
                webcamTexture.Play();
            }
        }

        if (Input.GetKeyDown("p"))
        {
            if (webcamTexture.isPlaying)
            {
                webcamTexture.Stop();
            }
        }

        if (Input.GetKeyDown("x"))
        {
            TakeSnapshot();
        }
    }

    void TakeSnapshot()
    {
        Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
        snapshot.SetPixels(webcamTexture.GetPixels());
        snapshot.Apply();

        string filename = savePath + "/Snapshot_" + captureCounter + ".png";

        byte[] snapshotBytes = snapshot.EncodeToPNG();

        System.IO.File.WriteAllBytes(filename, snapshotBytes);

        Debug.Log("Snapshot taken and saved to: " + filename);

        captureCounter++;
    }
}
