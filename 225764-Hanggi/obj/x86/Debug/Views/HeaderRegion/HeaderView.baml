   M S B A M L   `   `   `  ����  225764-Hanggi    HMI.HeaderView   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $��80��5      $
��1920��6      FP_Dark#���   6&   .��5      � -   5          �Name$  
LayoutRoot��5      .+�5   
     VisiWin.Controls.Button  -   5          Name$ barcode��5      $��48��6%   $��80��61   $��	800,0,0,0q�6<   $	��Top=�6O   $��Center=�6g     B_BarcodeScanner#���  6�    �� 	IsDefault .    SymbolResourceKey$ BarcodeScanner��6�   5
         VisiWin.Controls.TextBlock  5   
   -   5          Name$ 	AlarmText��5       �� Padding$ 10,5,0,0q�6*   $��0,48,0,0q�6=    
 FP_Red#���  6O   
�������$��SemiBold"�6�   $��16(�6�   �� 5   
   
�������$��3,3,0,0q�6$   $
��Left=�65   $	��Top=�6P   $��42��6h   $	��110��6t    �� CornerRadius$ 2��6�   ._�5      &   VisiWin.Controls.SymbolPresenter  $��Center=�6!   $��Center=�6>     H_ForplanLogo   Symbol# �  6Y   5      �� 5   
   $��8��6   $��Stretch=�6   #���  6=   $��Bottom=�6]    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   Color$	 White��6#   
   	Direction$	
 270Q�61      Opacity$	 0.7Q�6A   5        VisiWin.Controls.Clock  5      $��Right=�6   $��12(�6,   $��Normal"�6:   ���	#FFFFFFFF$��Segoe UI)�6e   $��0,0,8,56q�6{   $	��250��6�   $��24��6�   $��Right=�6�      
FormatDate$ @NamedLongDate��6�      
FormatTime$ 
@ShortTime��6�     5   
   $��Right=�6      DateTimeMode$ TimeOnly=�6/   $��14(�6G   ���	#FFFFFFFF$��Segoe UI)�6l   $
��Bold"�6�   $��0,24,8,0q�6�   $��151.5��6�   $��24��6�   $	��Top=�6�   $��Right=�6�   $��Center=�6�   5      5      