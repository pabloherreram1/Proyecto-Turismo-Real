   M S B A M L   `   `   `  ����H  DTurismoRealFF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:TurismoRealFF.Vistas.Mantenedores.Clientes*TurismoRealFF.Vistas.Mantenedores.Clientes  5   	   B    <TurismoRealFF.Vistas.Mantenedores.Clientes.Modificar_cliente   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Jlocal8clr-namespace:TurismoRealFF.Vistas.Mantenedores.Clientes     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  modificar_cliente��5   	   $	��600��5   R   $
��1024��6_    � WindowStyle$
 None=�6l    � WindowStartupLocation$ CenterScreen=�6   '  !System.Windows.Shell.WindowChrome   WindowChrome 5	        5
   
      CaptionHeight$ 0Q�6    � 	Resources 5         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  	CloseMenu��%�  &	        &	 �    �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $		 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $	 50Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $		 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItem��6�   .\�5        $ 0��6'   $
	 -250Q�63     5      $ 0:0:0.5��6'   $
	 -250Q�69     5      $ 0:0:0.7��6'   $	 0Q�69   5      U� 5       $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ button��6�   .\�5!        $ 0��6'   $	 0Q�63     5"      $ 0:0:0.5��6'   $	 0Q�69     5#      $ 0:0:1.5��6'   $	 1Q�69   5$      U� 5%      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ button��6�   .\�5&        $ 0��6'   $	 0Q�63     5'      $ 0:0:0.5��6'   $	 0Q�69     5(      $ 0:0:1.5��6'   $	 1Q�69   5)      5*      �� 5+   
   .��5,      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�5-        $ 0��6'   $		 250Q�63     5.      $ 0:0:0.5��6'   $	 0Q�69   5/      U� 50      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�51        $ 0��6'   $	 50Q�63     52      $ 0:0:0.5��6'   $	 0Q�69   53      U� 54      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�55        $ 0��6'   $		 250Q�63     56      $ 0:0:0.5��6'   $	 0Q�69   57      58      59      
 � Triggers
 5:      :� 5;   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5<      �� #��[  6   5=      :� 5>   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5?      �� -   5         ��Name$ CloseMenu_BeginStoryboard��5?      #��[ 6A   5@      .��5B      � ���	#FF3580BF.+�5C   
   �� -   5         ��Name$ StackPanelMenu��5C      $	��250��6-   $
��Left=�69   $��
-250 0 0 0q�6T    J� RenderTransformOrigin$ 0.5,0.5&�6h   z�5D      V� 5E      .~�5F      �� �� 5G      �� 5H      T� 5I      5J      .+�5L      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   $	��100��6J   $��Center=�6W   .+�5M      �� -   5         ��Name$ ButtonAtras��5M       0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6.   $��0q�6�   $��50��6�   $��50��6�   $��10q�6�   ��6t   Z� ��6�   Z� .��5N      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ KeyboardReturn=�6.   $��40��6D   $��40��6O   5O      �� 5P      -   5        $ button��5P      #��[ 6)   $��0q�6�   $��80��6�   $��80��6�   $��10q�6�   $ 0.5,0.5&�6�   ��6o   Z� z�5Q      V� 5R      .~�5S      �� �� 5T      �� 5U      T� 5V      5W      ��5Y      �� 5Z       �� ImageSource$ /Imagenes/turismo.ico��6%    j� Stretch$ Uniform=�6I   5\      �� 5]      #��[ 6   $��0q�6�   $��50��6�   $��50��6�   $��10q�6�   ��6_   Z� ��6u   Z� .��5^        $ InformationOutline=�6.   $��40��6H   $��40��6S   5_      5`      �� 5a      .@�5b      �� -   5         ��Name$ listViewItem��5b      $��60��65   $ 0.5,0.5&�6A   z�5c      V� 5d      .~�5e      �� �� 5f      �� 5g      T� 5h      5i      .��5k      �� $ 
Horizontal=�6!   $
��10 0q�6:   $	��213��6H   .+�5l        $ 	Backspace=�62   $��30��6C   $��30��6N   $��Center=�6Z   $��5q�6u   �� 5m      -   5        $ ButtonMenuM��5m   !   $	��157��66   $��30��6B   $��0q�6N   ��6Z   Z� ��6p   Z� .��5n      �� $��Menu Mantenedores��6(   $��Center=�6A   $	��139��6\   $ 0.518,0.488&�6h   5o      5p      5q      5u      5v      � 5w   
   -   5         �Name$ GridMain��5w      ���	#FFFBFBFB$
��1024��68   $ 0.5,0.5&�6E   z�5x      V� 5y      .~�5z      �� �� 5{      �� 5|      T� 5}      5~       � ColumnDefinitions 5�      �� 5�      $��* �6#   �� 5�      $	��250 �6#   .+�5�      � $��1��6   ���	#FF3580BF.+�5�      �� $	��150��6   $	��Top=�6%   $��/Imagenes/back.jpg��6=   $��UniformToFill=�6Y   A� 5�      $	��151��6   $	��188��6'   $	��Top=�63   $��Right=�6K   $��	0,49,20,0q�6g   
���������5�      �� 5�      $ /Imagenes/turismo.ico��6%   $ Uniform=�6I   5�      �� 5�      $�� ��6   
�������$��28(�67   $��Nirmala UI Semilight)�6E   $��10 100q�6g   $	��Top=�6w   �� 5�      $��0 150q�6   .+�5�      � $��60��6   $��
20 50 20 0q�6'    5�      �� 5�      $��* �6/   �� 5�      $��* �6/    � RowDefinitions 5�      �� 5�      $��30 �6,   �� 5�      $��30 �6,   .+�5�      �� $��	FOLLOWERS��6$   $��Bottom=�65   ���	#FFFBFBFB$��5,0,5,5q�6g   �� 5�      $
��1.5K��6$   $	��Top=�60   ���	#FFFBFBFB$��1��6_   $
��10 0q�6l   �� 5�      $��	FOLLOWING��6$   $��Bottom=�65   ���	#FFFBFBFB$��5,0,5,5q�6g   $��1��6x   �� 5�      $
��2.3K��6$   $	��Top=�60   ���	#FFFBFBFB$��1��6_   $
��10 0q�6l   $��1��6z   5�      �� 5�      $
��Wrap=�6    $��10q�64   ���	#FFFBFBFB$��14(�6W   ��Estimado administrador, en esta sección es el mantenimiento del cliente, puede buscarlo por rut y luego presionar click derecho y se cargaran los datos previos para ser modificados o eliminados.6)  5�      5�      � 5�      .+�5�      �� -	   5        $ ButtonCloseMenu��5�      #��[ 62   $��30��6x   $��30��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��5q�6�   $y�	Collapsed=�6$  ��6�   Z� ��6�   Z� .��5�        $
 Menu=�6.   ���	#FF3580BF6:   5�      �� 5�      -
   5        $ ButtonOpenMenu��5�      #��[ 61   $��30��6w   $��30��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��5q�6�   ��6�   Z� ��6�   Z� .��5�        $
 Menu=�6.   ���	#FF3580BF6:   5�      5�      � 5�      .+�5�      � $
��Left=�6   $	��392��62   $��	58,61,0,0q�6?   $	��Top=�6R   $	��664��6j   ���	#FFF5F4F4.+�5�      �� -   5         ��Name$ txt_rut��5�      $
��Left=�6/   $��23��6J   $��
241,43,0,0q�6V    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��120��6�   ���	#890000006�   �� 5�      -   5        $ txt_dv��5�      $
��Left=�6.   $��23��6I   $��
386,43,0,0q�6U   $
 Wrap=�6i   $	��Top=�6}   $��26��6�   ���	#890000006�   �� 5�      -   5         ��Name$ lbl_rut��5�      $
��Rut:��6-   $
��Left=�6<   $��
192,40,0,0q�6W   $	��Top=�6k   $ 	1.429,0.5&�6�   ���	#DD0000006�   �� 5�      -   5        $ 	lbl_guion��5�      $��-��6/   $
��Left=�6;   $��
366,43,0,0q�6V   $	��Top=�6j   $ -0.733,-2.423&�6�   $��23��6�   ���	#DD0000006�   �� 5�      -   5        $ 
lbl_nombre��5�      $��Nombre:��60   $
��Left=�6B   $��
80,223,0,0q�6]   $	��Top=�6q   ���	#DD000000$y�Hidden=�6�   �� 5�      -   5        $ 
txt_nombre��5�      $
��Left=�62   $��23��6M   $��
53,250,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $	��120��6�   ���	#89000000$y�Hidden=�6�   �� 5�      -   5        $ lbl_apellido��5�      $��	Apellido:��62   $
��Left=�6F   $��
80,274,0,0q�6a   $	��Top=�6u   $y�Hidden=�6�   ���	#DD0000006�   �� 5�      -   5        $ txt_apellido��5�      $
��Left=�64   $��23��6O   $��
53,299,0,0q�6[   $
 Wrap=�6o   $	��Top=�6�   $	��120��6�   $y�Hidden=�6�   ���	#890000006�   �� 5�      -   5        $ lbl_telefono��5�      $��
Teléfono:��62   $
��Left=�6F   $��
80,323,0,0q�6a   $	��Top=�6u   $ -2.759,7.423&�6�   $y�Hidden=�6�   ���	#DD0000006�   �� 5�      -   5        $ txt_telefono��5�      $
��Left=�64   $��23��6O   $��
53,347,0,0q�6[   $
 Wrap=�6o   $	��Top=�6�   $	��120��6�   $ 0.342,0&�6�   $y�Hidden=�6�   ���	#890000006�   �� 5�      -   5        $ 	lbl_email��5�      $��Email:��6/   $
��Left=�6@   $��534,232,0,0q�6[   $	��Top=�6p   $ 0.951,-0.038&�6�   $y�Hidden=�6�   ���	#DD0000006�   �� 5�      -   5        $ 	txt_email��5�      $
��Left=�61   $��37��6L   $��490,263,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $	��120��6�   {�.  $y�Hidden=�6�   ���	#890000006�   �� 5�      -   5        $ lbl_pass��5�      $��Contraseña:��6.   $
��Left=�6D   $��520,305,0,0q�6_   $	��Top=�6t   $y�Hidden=�6�   ���	#DD0000006�   �� 5�      -   5        $ txt_pass��5�      $
��Left=�60   $��23��6K   $��490,336,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��120��6�   $y�Hidden=�6�   ���	#890000006�   &   System.Windows.Controls.DataGrid  5�      -   5          Name$ dt_lista��5�      $
��Left=�61   $	��133��6L   $��	53,87,0,0q�6Y   $	��Top=�6l   $	��557��6�   ���	#890000006�   �� 5�      -   5        $ 
btn_buscar��5�      $��Buscar��61   $
��Left=�6B   $��
450,46,0,0q�6]   $	��Top=�6q   $��75��6�   6�   �� 5�      -   5        $ 
lbl_region��5�      $��Región:��60   $
��Left=�6B   $��312,220,0,0q�6]   $	��Top=�6r   $y�Hidden=�6�   ���	#DD0000006�   �� 5�      -   5         ��Name$ 
cmb_region��5�      $
��Left=�63   $��276,251,0,0q�6N   $	��Top=�6c   $	��120��6{   ���	#89000000$y�Hidden=�6�   �� 5�      -   5        $ lbl_provincia��5�      $��
Provincia:��63   $
��Left=�6H   $��307,274,0,0q�6c   $	��Top=�6x   $y�Hidden=�6�   ���	#DD0000006�   �� 5�      -   5        $ cmb_provincia��5�      $
��Left=�66   $��276,300,0,0q�6Q   $	��Top=�6f   $	��120��6~   ���	#89000000$y�Hidden=�6�   �� 5�      -   5        $ 
lbl_ciudad��5�      $��Ciudad:��60   $
��Left=�6B   $��313,322,0,0q�6]   $	��Top=�6r   $ 0.5,0&�6�   $y�Hidden=�6�   ���	#DD0000006�   �� 5�      -    5        $ 
cmb_ciudad��5�      $
��Left=�63   $��276,347,0,0q�6N   $	��Top=�6c   $	��120��6{   $y�Hidden=�6�   ���	#890000006�   �� 5�      -!   5        $ 
txt_userid��5�      $
��Left=�62   $��23��6M   $��628,226,0,0q�6Y   $
 Wrap=�6n   $	��Top=�6�   $��26��6�   $ 0.192,-0.13&�6�   $y�Hidden=�6�   ���	#890000006�   �� 5�      -"   5        $ txt_ciudadidc��5�      $
��Left=�65   $��23��6P   $��628,259,0,0q�6\   $
 Wrap=�6q   $	��Top=�6�   $��26��6�   $y�Hidden=�6�   ���	#890000006�   �� 5�      -#   5        $ txt_rutc��5�      $
��Left=�60   $��23��6K   $��628,294,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $��26��6�   $y�Hidden=�6�   ���	#890000006�   �� 5�      -$   5        $ txt_dvc��5�      $
��Left=�6/   $��23��6J   $��628,328,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $��26��6�   $y�Hidden=�6�   ���	#890000006�   �� 5�      -%   5        $ txt_nombre1��5�      $
��Left=�63   $��23��6N   $��628,363,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $��26��6�   $y�Hidden=�6�   ���	#890000006�   5�      � 5�      $��29,482,27,10q�6   ���	#FFFBFBFB.+�5�      �� -&   5        $ btn_eliminar��5�      $��Eliminar��63   $��	64,21,0,0q�6F   $��40��6Y   $	��Top=�6e   $
��Left=�6}   $	��130��6�   6�   �� 5�      -'   5        $ btn_modificar��5�      $��	Modificar��64   $��
534,21,0,0q�6H   $��40��6\   $	��Top=�6h   $
��Left=�6�   $	��130��6�   6�   5�      5�      5�      �� 5�   
   $ 
Horizontal=�6   $	��Top=�6.   $��40��6F   $��Right=�6R   $��10q�6n   .+�5�      �� #��[ 6   $��30��6[   $��30��6f   $��0q�6r   ��6~   Z� ��6�   Z� .��5�        $
 Bell=�6*   5�      �� 5�      -(   5        $ ButtonClose��5�      #��[ 6*   $��30��6p   $��30��6{   $��0q�6�   ��6�   Z� ��6�   Z� .��5�        $ Power=�6*   5�      5�      5�      5�      