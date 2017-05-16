using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnector : MonoBehaviour {

	public List<IoConnection> _connections;

	public void Start () {

		_connections = new List<IoConnection> ();

	}

	public void RemoveAllConnections() {

		// On Destroy, remove all connections
		foreach (IoConnection i in _connections) {
			i.RemoveConnection ();
			// _connections.Remove (i);
		}

	}

}
