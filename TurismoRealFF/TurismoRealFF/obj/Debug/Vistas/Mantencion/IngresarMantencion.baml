   M S B A M L   `   `   `  ����H  DTurismoRealFF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:TurismoRealFF.Vistas.MantencionTurismoRealFF.Vistas.Mantencion  5   	   8    2TurismoRealFF.Vistas.Mantencion.IngresarMantencion   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:TurismoRealFF.Vistas.Mantencion     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  RegistrarMantencion��5   	   $	��600��5   R   $
��1024��6_    � WindowStyle$
 None=�6l    � WindowStartupLocation$ CenterScreen=�6   '  !System.Windows.Shell.WindowChrome   WindowChrome 5	        5
   
      CaptionHeight$ 0Q�6    � 	Resources 5         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  	CloseMenu��%�
  &	        &	 !    �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $		 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $	 50Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $		 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItem��6�   .\�5        $ 0��6'   $
	 -250Q�63     5      $ 0:0:0.5��6'   $
	 -250Q�69     5      $ 0:0:0.7��6'   $	 0Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItem1��6�   .\�5         $ 0��6'   $
	 -250Q�63     5!      $ 0:0:0.5��6'   $
	 -250Q�69     5"      $ 0:0:0.9��6'   $	 0Q�69   5#      U� 5$      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItem2��6�   .\�5%        $ 0��6'   $
	 -250Q�63     5&      $ 0:0:0.5��6'   $
	 -250Q�69     5'      $ 0:0:1.1��6'   $	 0Q�69   5(      U� 5+      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ button��6�   .\�5,        $ 0��6'   $	 0Q�63     5-      $ 0:0:0.5��6'   $	 0Q�69     5.      $ 0:0:1.5��6'   $	 1Q�69   5/      U� 50      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ button��6�   .\�51        $ 0��6'   $	 0Q�63     52      $ 0:0:0.5��6'   $	 0Q�69     53      $ 0:0:1.5��6'   $	 1Q�69   54      55      �� 56   
   .��57      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�58        $ 0��6'   $		 250Q�63     59      $ 0:0:0.5��6'   $	 0Q�69   5:      U� 5;      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�5<        $ 0��6'   $	 50Q�63     5=      $ 0:0:0.5��6'   $	 0Q�69   5>      U� 5?      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�5@        $ 0��6'   $		 250Q�63     5A      $ 0:0:0.5��6'   $	 0Q�69   5B      5C      5D      
 � Triggers
 5E      :� 5F   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5G      �� #��[  6   5H      :� 5I   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5J      �� -   5         ��Name$ CloseMenu_BeginStoryboard��5J      #��[ 6A   5K      .��5M      � ���	#FF3580BF.+�5N   
   �� -   5         ��Name$ StackPanelMenu��5N      $	��250��6-   $
��Left=�69   $��
-250 0 0 0q�6T    J� RenderTransformOrigin$ 0.5,0.5&�6h   z�5O      V� 5P      .~�5Q      �� �� 5R      �� 5S      T� 5T      5U      .+�5W      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   $	��100��6J   $��Center=�6W   .+�5X      �� -   5         ��Name$ ButtonAtras��5X       0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6.   $��0q�6�   $��50��6�   $��50��6�   $��10q�6�   ��6t   Z� ��6�   Z� .��5Y      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ KeyboardReturn=�6.   $��40��6D   $��40��6O   5Z      �� 5[      -   5        $ button��5[      #��[ 6)   $��0q�6�   $��80��6�   $��80��6�   $��10q�6�   $ 0.5,0.5&�6�   ��6o   Z� z�5\      V� 5]      .~�5^      �� �� 5_      �� 5`      T� 5a      5b      ��5d      �� 5e       �� ImageSource$ /Imagenes/turismo.ico��6%    j� Stretch$ Uniform=�6I   5g      �� 5h      #��[ 6   $��0q�6�   $��50��6�   $��50��6�   $��10q�6�   ��6_   Z� ��6u   Z� .��5i        $ InformationOutline=�6.   $��40��6H   $��40��6S   5j      5k      �� 5l      $	��298��6   .@�5m      �� -   5         ��Name$ listViewItem��5m      $��60��65   $ 0.5,0.5&�6A   z�5n      V� 5o      .~�5p      �� �� 5q      �� 5r      T� 5s      5t      .��5v      �� $ 
Horizontal=�6!   $
��10 0q�6:   .+�5w        $ UserAdd=�62   $��30��6A   $��30��6L   $��Center=�6X   $��5q�6s   �� 5x      -   5        $ ButtonDisponibilidad��5x   !   $��98��6?   $��30��6J   $��0q�6V   ��6b   Z� ��6x   Z� .��5y      �� $��Disponibilidad��6(   $��Center=�6>   $��98��6Y   $ 0.518,0.488&�6d   5z      5{      5|      �� 5}      -   5        $ listViewItem1��5}      $��60��66   $ 0.5,0.5&�6B   z�5~      V� 5      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      .��5�      �� $ 
Horizontal=�6!   $
��10 0q�6:   .+�5�        $ OfficeBuilding=�62   $��30��6H   $��30��6S   $��Center=�6_   $��5q�6z   �� 5�      -	   5        $ ButtonIngresarM��5�   !   $	��158��6:   $��30��6F   $��0q�6R   ��6^   Z� ��6t   Z� .��5�      �� $��Ingresar Mantención��6(   $��Center=�6C   $	��157��6^   $ 0.518,0.488&�6j   5�      5�      5�      �� 5�      -
   5        $ listViewItem2��5�      $��60��66   $ 0.5,0.5&�6B   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      .��5�      �� $ 
Horizontal=�6!   $
��10 0q�6:   .+�5�        $ Helmet=�62   $��30��6@   $��30��6K   $��Center=�6W   $��5q�6r   �� 5�      -   5        $ ButtonListarM��5�   !   $	��124��68   $��30��6D   $��0q�6P   ��6\   Z� ��6r   Z� .��5�      �� $��Listar Mantención��6(   $��Center=�6A   $	��124��6\   $ 0.518,0.488&�6h   5�      5�      5�      5�      5�      � 5�   
   -   5         �Name$ GridMain��5�      ���	#FFFBFBFB$
��1024��68   $ 0.5,0.5&�6E   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�       � ColumnDefinitions 5�      �� 5�      $��* �6#   �� 5�      $	��250 �6#   .+�5�      � $��1��6   ���	#FF3580BF.+�5�      �� $	��150��6   $	��Top=�6%   $��/Imagenes/back.jpg��6=   $��UniformToFill=�6Y   A� 5�      $	��151��6   $	��188��6'   $	��Top=�63   $��Right=�6K   $��	0,49,20,0q�6g   
���������5�      �� 5�      $ /Imagenes/turismo.ico��6%   $ Uniform=�6I   5�      �� 5�      $�� ��6   
�������$��28(�67   $��Nirmala UI Semilight)�6E   $��10 100q�6g   $	��Top=�6w   �� 5�      $��0 150q�6   .+�5�      � $��60��6   $��
20 50 20 0q�6'    5�      �� 5�      $��* �6/   �� 5�      $��* �6/    � RowDefinitions 5�      �� 5�      $��30 �6,   �� 5�      $��30 �6,   .+�5�      �� $��	FOLLOWERS��6$   $��Bottom=�65   ���	#FFFBFBFB$��5,0,5,5q�6g   �� 5�      $
��1.5K��6$   $	��Top=�60   ���	#FFFBFBFB$��1��6_   $
��10 0q�6l   �� 5�      $��	FOLLOWING��6$   $��Bottom=�65   ���	#FFFBFBFB$��5,0,5,5q�6g   $��1��6x   �� 5�      $
��2.3K��6$   $	��Top=�60   ���	#FFFBFBFB$��1��6_   $
��10 0q�6l   $��1��6z   5�      �� 5�      $
��Wrap=�6    $��10q�64   ���	#FFFBFBFB$��14(�6W   rpEstimado Administrador en esta seccion, podra ingresar tanto como recinto, departamento y producto a manteción.6�   5�      5�      � 5�      .+�5�      �� -   5        $ ButtonCloseMenu��5�      #��[ 62   $��30��6x   $��30��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��5q�6�   $y�	Collapsed=�6$  ��6�   Z� ��6�   Z� .��5�        $
 Menu=�6.   ���	#FF3580BF6:   5�      �� 5�      -   5        $ ButtonOpenMenu��5�      #��[ 61   $��30��6w   $��30��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��5q�6�   ��6�   Z� ��6�   Z� .��5�        $
 Menu=�6.   ���	#FF3580BF6:   5�      � 5�      $
��Left=�6   $	��392��62   $��	10,61,0,0q�6?   $	��Top=�6R   $	��759��6j   ���	#FFF5F4F4.+�5�      �� -   5         ��Name$ lbl_recinto��5�      $��Recinto:��61   $
��Left=�6D   $��	53,25,0,0q�6_   $	��Top=�6r   ���	#DD0000006�   �� 5�      -   5         ��Name$ cmb_recinto��5�      $
��Left=�64   $��
110,25,0,0q�6O   $	��Top=�6c   $	��120��6{   ���	#890000006�   �� 5�      -   5        $ lbl_dpto��5�      $��Departamento:��6.   $
��Left=�6F   $��
266,25,0,0q�6a   $	��Top=�6u   $ 0.471,0.123&�6�   ���	#DD0000006�   �� 5�      -   5        $ 	cmb_depto��5�      $
��Left=�62   $��
360,25,0,0q�6M   $	��Top=�6a   $	��120��6y   ���	#890000006�   �� 5�      -   5        $ lbl_producto��5�      $��	Producto:��62   $
��Left=�6F   $��
513,26,0,0q�6a   $	��Top=�6u   ���	#DD0000006�   �� 5�      -   5        $ cmb_producto��5�      $
��Left=�65   $��
579,25,0,0q�6P   $	��Top=�6d   $	��120��6|   ���	#890000006�   �� 5�      -   5        $ btn_disponibilidad��5�      $��Escoger Disponibilidad��69   $
��Left=�6Z   $��
274,74,0,0q�6u   $	��Top=�6�   $	��192��6�   $��39��6�   6�   �� 5�      -   5        $ lbl_descripcion��5�      $��Descripción��65   $
��Left=�6K   $��110,137,0,0q�6f   $	��Top=�6{   ���	#DD0000006�   �� 5�      -   5         ��Name$ txt_descripcion��5�      $
��Left=�67   $	��113��6R   $��
53,168,0,0q�6_    �� TextWrapping$
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��185��6�   ���	#890000006�   �� 5�      -   5        $ 	lbl_total��5�      $��Precio de Reparación��6/   $
��Left=�6N   $��305,139,0,0q�6i   $	��Top=�6~   ���	#DD0000006�   �� 5�      -   5        $ 	txt_total��5�      $
��Left=�61   $��23��6L   $��307,170,0,0q�6X   $
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��120��6�   ���	#890000006�   �� 5�      -   5        $ lbl_fechaIni��5�      $��Fecha de Inicio��62   $
��Left=�6L   $��531,139,0,0q�6g   $	��Top=�6|   ���	#DD0000006�   �� 5�      -   5        $ txt_fechaIni��5�      $
��Left=�64   $��23��6O   $��527,170,0,0q�6[   $
 Wrap=�6p   $	��Top=�6�   $	��101��6�   ���	#89000000{�.  6�   �� 5�      -   5        $ lbl_fechaTer��5�      $��Fecha de Término��62   $
��Left=�6M   $��525,227,0,0q�6h   $	��Top=�6}   ���	#DD0000006�   �� 5�      -   5        $ txt_fechaTer��5�      $
��Left=�64   $��23��6O   $��527,258,0,0q�6[   $
 Wrap=�6p   $	��Top=�6�   $	��101��6�   ���	#89000000{�.  6�   � 5�      $
��Left=�6   $��42��66   $��
708,18,0,0q�6B   $	��Top=�6V   $��50��6n   ���	#FF3C3C3C6y   �� 5�      -   5         ��Name$ ckb_producto��5�      $�� ��65   $
��Left=�6@   $��
724,32,0,0q�6[   $	��Top=�6o   ���	#DD0000006�   � 5�      $
��Left=�6   $��42��66   $��3,18,0,0q�6B   $	��Top=�6T   $��50��6l   ���	#FF3C3C3C.+�5�      �� -   5        $ ckb_recinto��5�   #   $�� ��68   $
��Left=�6C   $��	20,10,0,0q�6^   $	��Top=�6q   ���	#DD0000006�   5�      5�      � 5�      $��84,492,84,0q�6   ���#FFF.+�5�      �� -    5        $ btn_registrar��5�      $��	Registrar��64   $
��Left=�6H   $��
232,27,0,0q�6c   $	��Top=�6w   $	��144��6�   $��44��6�   6�   5�      5�      5�      �� 5�   
   $ 
Horizontal=�6   $	��Top=�6.   $��40��6F   $��Right=�6R   $��10q�6n   .+�5�      �� #��[ 6   $��30��6[   $��30��6f   $��0q�6r   ��6~   Z� ��6�   Z� .��5�        $
 Bell=�6*   5�      �� 5�      -!   5        $ ButtonClose��5�      #��[ 6*   $��30��6p   $��30��6{   $��0q�6�   ��6�   Z� ��6�   Z� .��5�        $ Power=�6*   5�      5�      5�      5�      