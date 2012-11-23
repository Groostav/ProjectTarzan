// Type: UnityEngine.Transform
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Program Files (x86)\Unity\Editor\Data\Managed\UnityEngine.dll

using System.Collections;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
  public sealed class Transform : Component, IEnumerable
  {
    public Vector3 position
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_position(out vector3);
        return vector3;
      }
      set
      {
        this.INTERNAL_set_position(ref value);
      }
    }

    public Vector3 localPosition
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_localPosition(out vector3);
        return vector3;
      }
      set
      {
        this.INTERNAL_set_localPosition(ref value);
      }
    }

    public Vector3 eulerAngles
    {
      get
      {
        return this.rotation.eulerAngles;
      }
      set
      {
        this.rotation = Quaternion.Euler(value);
      }
    }

    public Vector3 localEulerAngles
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_localEulerAngles(out vector3);
        return vector3;
      }
      set
      {
        this.INTERNAL_set_localEulerAngles(ref value);
      }
    }

    public Vector3 right
    {
      get
      {
        return this.rotation * Vector3.right;
      }
      set
      {
        this.rotation = Quaternion.FromToRotation(Vector3.right, value);
      }
    }

    public Vector3 up
    {
      get
      {
        return this.rotation * Vector3.up;
      }
      set
      {
        this.rotation = Quaternion.FromToRotation(Vector3.up, value);
      }
    }

    public Vector3 forward
    {
      get
      {
        return this.rotation * Vector3.forward;
      }
      set
      {
        this.rotation = Quaternion.LookRotation(value);
      }
    }

    public Quaternion rotation
    {
      get
      {
        Quaternion quaternion;
        this.INTERNAL_get_rotation(out quaternion);
        return quaternion;
      }
      set
      {
        this.INTERNAL_set_rotation(ref value);
      }
    }

    public Quaternion localRotation
    {
      get
      {
        Quaternion quaternion;
        this.INTERNAL_get_localRotation(out quaternion);
        return quaternion;
      }
      set
      {
        this.INTERNAL_set_localRotation(ref value);
      }
    }

    public Vector3 localScale
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_localScale(out vector3);
        return vector3;
      }
      set
      {
        this.INTERNAL_set_localScale(ref value);
      }
    }

    public Transform parent { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] set; }

    public Matrix4x4 worldToLocalMatrix
    {
      get
      {
        Matrix4x4 matrix4x4;
        this.INTERNAL_get_worldToLocalMatrix(out matrix4x4);
        return matrix4x4;
      }
    }

    public Matrix4x4 localToWorldMatrix
    {
      get
      {
        Matrix4x4 matrix4x4;
        this.INTERNAL_get_localToWorldMatrix(out matrix4x4);
        return matrix4x4;
      }
    }

    public Transform root { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public int childCount { [WrapperlessIcall, MethodImpl(MethodImplOptions.InternalCall)] get; }

    public Vector3 lossyScale
    {
      get
      {
        Vector3 vector3;
        this.INTERNAL_get_lossyScale(out vector3);
        return vector3;
      }
    }

    private Transform()
    {
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_get_position(out Vector3 value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_set_position(ref Vector3 value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_get_localPosition(out Vector3 value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_set_localPosition(ref Vector3 value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_get_localEulerAngles(out Vector3 value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_set_localEulerAngles(ref Vector3 value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_get_rotation(out Quaternion value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_set_rotation(ref Quaternion value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_get_localRotation(out Quaternion value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_set_localRotation(ref Quaternion value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_get_localScale(out Vector3 value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_set_localScale(ref Vector3 value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_get_worldToLocalMatrix(out Matrix4x4 value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_get_localToWorldMatrix(out Matrix4x4 value);

    public void Translate(Vector3 translation)
    {
      Space relativeTo = Space.Self;
      this.Translate(translation, relativeTo);
    }

    public void Translate(Vector3 translation, Space relativeTo)
    {
      if (relativeTo == Space.World)
        this.position += translation;
      else
        this.position += this.TransformDirection(translation);
    }

    public void Translate(float x, float y, float z)
    {
      Space relativeTo = Space.Self;
      this.Translate(x, y, z, relativeTo);
    }

    public void Translate(float x, float y, float z, Space relativeTo)
    {
      this.Translate(new Vector3(x, y, z), relativeTo);
    }

    public void Translate(Vector3 translation, Transform relativeTo)
    {
      if ((bool) ((Object) relativeTo))
        this.position += relativeTo.TransformDirection(translation);
      else
        this.position += translation;
    }

    public void Translate(float x, float y, float z, Transform relativeTo)
    {
      this.Translate(new Vector3(x, y, z), relativeTo);
    }

    public void Rotate(Vector3 eulerAngles)
    {
      Space relativeTo = Space.Self;
      this.Rotate(eulerAngles, relativeTo);
    }

    public void Rotate(Vector3 eulerAngles, Space relativeTo)
    {
      Quaternion quaternion = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
      if (relativeTo == Space.Self)
        this.localRotation = this.localRotation * quaternion;
      else
        this.rotation = this.rotation * Quaternion.Inverse(this.rotation) * quaternion * this.rotation;
    }

    public void Rotate(float xAngle, float yAngle, float zAngle)
    {
      Space relativeTo = Space.Self;
      this.Rotate(xAngle, yAngle, zAngle, relativeTo);
    }

    public void Rotate(float xAngle, float yAngle, float zAngle, Space relativeTo)
    {
      this.Rotate(new Vector3(xAngle, yAngle, zAngle), relativeTo);
    }

    public void Rotate(Vector3 axis, float angle)
    {
      Space relativeTo = Space.Self;
      this.Rotate(axis, angle, relativeTo);
    }

    public void Rotate(Vector3 axis, float angle, Space relativeTo)
    {
      // ISSUE: unable to decompile the method.
    }

    public void RotateAround(Vector3 point, Vector3 axis, float angle)
    {
      // ISSUE: unable to decompile the method.
    }

    public void LookAt(Transform target)
    {
      Vector3 up = Vector3.up;
      this.LookAt(target, up);
    }

    public void LookAt(Transform target, Vector3 worldUp)
    {
      if (!(bool) ((Object) target))
        return;
      this.LookAt(target.position, worldUp);
    }

    public void LookAt(Vector3 worldPosition, Vector3 worldUp)
    {
      Transform.INTERNAL_CALL_LookAt(this, ref worldPosition, ref worldUp);
    }

    public void LookAt(Vector3 worldPosition)
    {
      Vector3 up = Vector3.up;
      Transform.INTERNAL_CALL_LookAt(this, ref worldPosition, ref up);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static void INTERNAL_CALL_LookAt(Transform self, ref Vector3 worldPosition, ref Vector3 worldUp);

    public Vector3 TransformDirection(Vector3 direction)
    {
      return Transform.INTERNAL_CALL_TransformDirection(this, ref direction);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static Vector3 INTERNAL_CALL_TransformDirection(Transform self, ref Vector3 direction);

    public Vector3 TransformDirection(float x, float y, float z)
    {
      return this.TransformDirection(new Vector3(x, y, z));
    }

    public Vector3 InverseTransformDirection(Vector3 direction)
    {
      return Transform.INTERNAL_CALL_InverseTransformDirection(this, ref direction);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static Vector3 INTERNAL_CALL_InverseTransformDirection(Transform self, ref Vector3 direction);

    public Vector3 InverseTransformDirection(float x, float y, float z)
    {
      return this.InverseTransformDirection(new Vector3(x, y, z));
    }

    public Vector3 TransformPoint(Vector3 position)
    {
      return Transform.INTERNAL_CALL_TransformPoint(this, ref position);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static Vector3 INTERNAL_CALL_TransformPoint(Transform self, ref Vector3 position);

    public Vector3 TransformPoint(float x, float y, float z)
    {
      return this.TransformPoint(new Vector3(x, y, z));
    }

    public Vector3 InverseTransformPoint(Vector3 position)
    {
      return Transform.INTERNAL_CALL_InverseTransformPoint(this, ref position);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static Vector3 INTERNAL_CALL_InverseTransformPoint(Transform self, ref Vector3 position);

    public Vector3 InverseTransformPoint(float x, float y, float z)
    {
      return this.InverseTransformPoint(new Vector3(x, y, z));
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public void DetachChildren();

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public Transform Find(string name);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal void SendTransformChangedScale();

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private void INTERNAL_get_lossyScale(out Vector3 value);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public bool IsChildOf(Transform parent);

    public Transform FindChild(string name)
    {
      return this.Find(name);
    }

    public IEnumerator GetEnumerator()
    {
      return (IEnumerator) new Transform.Enumerator(this);
    }

    public void RotateAround(Vector3 axis, float angle)
    {
      Transform.INTERNAL_CALL_RotateAround(this, ref axis, angle);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static void INTERNAL_CALL_RotateAround(Transform self, ref Vector3 axis, float angle);

    public void RotateAroundLocal(Vector3 axis, float angle)
    {
      Transform.INTERNAL_CALL_RotateAroundLocal(this, ref axis, angle);
    }

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static void INTERNAL_CALL_RotateAroundLocal(Transform self, ref Vector3 axis, float angle);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public Transform GetChild(int index);

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public int GetChildCount();

    [WrapperlessIcall]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal bool IsNonUniformScaleTransform();

    private sealed class Enumerator : IEnumerator
    {
      private int currentIndex = -1;
      private Transform outer;

      public object Current
      {
        get
        {
          return (object) this.outer.GetChild(this.currentIndex);
        }
      }

      internal Enumerator(Transform outer)
      {
        this.outer = outer;
      }

      public bool MoveNext()
      {
        return ++this.currentIndex < this.outer.childCount;
      }

      public void Reset()
      {
        this.currentIndex = -1;
      }
    }
  }
}
