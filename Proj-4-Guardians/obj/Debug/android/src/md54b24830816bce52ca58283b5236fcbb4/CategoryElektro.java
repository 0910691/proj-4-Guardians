package md54b24830816bce52ca58283b5236fcbb4;


public class CategoryElektro
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Proj_4_Guardians.CategoryElektro, Proj-4-Guardians", CategoryElektro.class, __md_methods);
	}


	public CategoryElektro ()
	{
		super ();
		if (getClass () == CategoryElektro.class)
			mono.android.TypeManager.Activate ("Proj_4_Guardians.CategoryElektro, Proj-4-Guardians", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}