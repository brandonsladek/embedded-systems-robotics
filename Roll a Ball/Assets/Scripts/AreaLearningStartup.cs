using System.Collections;
using UnityEngine;
using Tango;

public class AreaLearningStartup : MonoBehaviour, ITangoLifecycle
{
	private TangoApplication m_tangoApplication;

	public void Start()
	{
		m_tangoApplication = FindObjectOfType<TangoApplication>();
		if (m_tangoApplication != null)
		{
			m_tangoApplication.Register(this);
			m_tangoApplication.RequestPermissions();
		}
	}

	public void OnTangoPermissions(bool permissionsGranted)
	{
		if (permissionsGranted)
		{
			AreaDescription[] list = AreaDescription.GetList();
			AreaDescription adfToUse = null;

			if (list.Length > 0)
			{
				foreach (AreaDescription areaDescription in list) 
				{
					AreaDescription.Metadata metadata = areaDescription.GetMetadata ();

					if (metadata.m_name.Equals("maybeThisOneAdf"))
					{
						adfToUse = areaDescription;
					}
				}

				m_tangoApplication.Startup(adfToUse);
			}
			else
			{
				// No Area Descriptions available.
				m_tangoApplication.Startup(null);
			}
		}
	}

	public void OnTangoServiceConnected()
	{
	}

	public void OnTangoServiceDisconnected()
	{
	}
}
