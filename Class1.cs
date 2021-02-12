﻿using System;
namespace GUI { 

public class NativeTreeView : System.Windows.Forms.TreeView
{
    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName,
                                            string pszSubIdList);

    protected override void CreateHandle()
    {
        base.CreateHandle();
        SetWindowTheme(this.Handle, "explorer", null);
    }
}

}