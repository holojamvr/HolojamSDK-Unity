// FlakeComponent.cs
// Created by Holojam Inc. on 16.02.17

using UnityEngine;

namespace Holojam.Network {

  /// <summary>
  /// Unity component containing a Flake for MonoBehaviours that need to work with Holojam data.
  /// </summary>
  public abstract class FlakeComponent : MonoBehaviour {

    /// <summary>
    /// A timestamp from the most recent update to this component's data.
    /// </summary>
    public float Timestamp {
      get { return timestamp; }
      internal set { timestamp = value; }
    }
    float timestamp;

    /// <summary>
    /// The difference (delta) between the current time and the most recent update.
    /// </summary>
    /// <returns>The float specified.</returns>
    public float DeltaTime() {
      return Time.unscaledTime - Timestamp;
    }

    /// <summary>
    /// Holojam data container. Protected to allow for direct modification in subclasses.
    /// When subclassing, make sure to create public-facing proxies for readability and
    /// controlling read/write access. See examples.
    /// </summary>
    internal protected Flake data = new Flake();

    /// <summary>
    /// Reset the flake data. A necessary override to allocate the optional members beforehand.
    /// </summary>
    public virtual void ResetData() {
      data = new Flake();
    }

    /// <summary>
    /// Awake() is overriden, by default resetting the data.
    /// </summary>
    protected virtual void Awake() {
      ResetData();
    }
  }
}