using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController :MonoBehaviour
{

    public static Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();

    /// <summary>
    /// �ݭn����Y�ӭ��Ī��ɭԻݭn�I�s����k�N�i�H�F
    /// </summary>
    /// <param name="dir">�o�O�A���Ī����|, �����bResources�ؿ��U</param>
    /// <param name="name">���Ī��W��</param>
    public static void PlaySE(string dir, string name)
    {
        AudioClip clip = LoadClip(dir, name.ToLower());
        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
        else                                                   
            Debug.LogError("Clip is Missing" + name);
    }
    public static AudioClip LoadClip(string dir, string name)
    {
        if (!audioDic.ContainsKey(name))
        {
            string dirMusic = dir + "/" + name;
            AudioClip clip = Resources.Load(dirMusic) as AudioClip;
            if (clip != null)
                audioDic.Add(clip.name, clip);
        }
        return audioDic[name];
    }

    ////�I�s����
    //private void AudioSourceShow()
    //{
    //    //�b��L���̭��I�s���ɭԥu�ݭn���W�I�o���R�A��k
    //    //�ثe�������ɮש�b(Resources/Cho_Sounds)�ؿ��U�A�ɦW��OnClick�A
    //    AudioSourceController.PlaySE("Cho_Sounds", "Choose");  //(�����ļ��񧹷|�۰ʧR��)
    //}
}
