using UnityEngine;
using System.IO;

public class SpyManager : MonoBehaviour
{
    private int clickCount = 0;
    private float totalTime = 0f;
    private string filePath;

    void Start()
    {
        // Obtenez le chemin d'accès au fichier dans le même dossier que le script
        filePath = Path.Combine(Application.dataPath, "actions_log.txt");

        // Vérifiez si le fichier existe déjà, s'il existe, supprimez-le pour créer un nouveau fichier
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    void Update()
    {
        // Si le bouton de la souris est cliqué, incrémente le nombre de clics
        if (Input.GetMouseButtonDown(0))
        {
            clickCount++;
        }
        if (Input.GetMouseButtonUp(0))
        {
            clickCount++;
        }
    }

    void OnApplicationQuit()
    {
        // Calculer le temps total écoulé depuis le démarrage de l'application
        totalTime += Time.realtimeSinceStartup;

        // Enregistrez le nombre total de clics et le temps total dans le fichier texte
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Total Actions: " + clickCount);
            writer.WriteLine("Total time: " + totalTime + " seconds");
        }
    }
}
