   M S B A M L   `   `   `  ����H  D3DModelViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:_3DModelViewer_3DModelViewer  5   	       _3DModelViewer.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:_3DModelViewer     5   	   X THelixToolkit.Wpf, Version=2.25.0.0, Culture=neutral, PublicKeyToken=52aa3500039caf0d(helixhttp://helix-toolkit.org/wpf  64     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   HelixToolkit.Wpf.HelixViewport3D  -   5        $��MainViewport��5
       
�������   Children. 5      $  HelixToolkit.Wpf.DefaultLights  5      �� 5   
    �� Orientation$ Vertical=�6   $
��Left=�6,   .+�5      �� -   5        $��
Load Model��5      6*   �� 5      -   5        $��
Reset View��5      6*   �� 5      -   5         � Minimum$	 0.1Q�5       � Maximum$ 10Q�6#    � Value$ 1Q�60   6:   5      5      5      