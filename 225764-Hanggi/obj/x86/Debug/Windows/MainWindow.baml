   M S B A M L   `   `   `  ����  225764-Hanggi    HMI.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5        � 
ResizeMode$  NoResize=�5       � WindowStyle$
 None=�6    � WindowState$ 	Maximized=�6+    � WindowStartupLocation$ CenterScreen=�6C   $
��1920��6h   $
��1080��6u   .��5      � -   5         �Name$ 
LayoutRoot��5       � UseLayoutRounding .  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5	      $��* �6   .+�5   
     VisiWin.Controls.Region  -   5          Name$ 
MainRegion��5         	StartView$ MO_MainView��6(   	   DesignTimeView$	 MainView��6@   $��1��6Z   $��Right=�6g     5   
   -   5        $ HeaderRegion��5      $ 
HeaderView��6*   $	 
HeaderView��6A   $��0��6]     5   
   -   5        $ AppBarRegion��5      $ 
AppbarView��6*   $	 
AppbarView��6A   $��1��6]   $
��Left=�6j     5   
   -   5        $ DialogRegion��5      $��2��6+     5   
   -   5        $ MessageBoxRegion��5      $��2��6.     5   
   -   5        $ TouchpadRegion��5      $��2��6,   5      5      