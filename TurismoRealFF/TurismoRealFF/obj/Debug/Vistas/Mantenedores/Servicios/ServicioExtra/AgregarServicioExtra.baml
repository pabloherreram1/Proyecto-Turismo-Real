   M S B A M L   `   `   `  ����H  DTurismoRealFF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Gclr-namespace:TurismoRealFF.Vistas.Mantenedores.Servicios.ServicioExtra9TurismoRealFF.Vistas.Mantenedores.Servicios.ServicioExtra  5   	   T    NTurismoRealFF.Vistas.Mantenedores.Servicios.ServicioExtra.AgregarServicioExtra   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   YlocalGclr-namespace:TurismoRealFF.Vistas.Mantenedores.Servicios.ServicioExtra     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   $	��600��6S   $
��1024��6`     � WindowStyle$
  None=�6m    � WindowStartupLocation$ CenterScreen=�6�   '  !System.Windows.Shell.WindowChrome   WindowChrome 5	        5
   
      CaptionHeight$ 0Q�6    � 	Resources 5         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�	  &	        &	 	    �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $	 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $ 50Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $	 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItem��6�   .\�5        $ 0��6'   $
 -250Q�63     5      $ 0:0:0.5��6'   $
 -250Q�69     5      $ 0:0:0.7��6'   $ 0Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ listViewItem1��6�   .\�5         $ 0��6'   $
 -250Q�63     5!      $ 0:0:0.5��6'   $
 -250Q�69     5"      $ 0:0:0.9��6'   $ 0Q�69   5#      U� 5%      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ button��6�   .\�5&        $ 0��6'   $ 0Q�63     5'      $ 0:0:0.5��6'   $ 0Q�69     5(      $ 0:0:1.5��6'   $ 1Q�69   5)      U� 5*      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ button��6�   .\�5+        $ 0��6'   $ 0Q�63     5,      $ 0:0:0.5��6'   $ 0Q�69     5-      $ 0:0:1.5��6'   $ 1Q�69   5.      5/      �� 50   
   .��51      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�52        $ 0��6'   $	 250Q�63     53      $ 0:0:0.5��6'   $ 0Q�69   54      U� 55      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�56        $ 0��6'   $ 50Q�63     57      $ 0:0:0.5��6'   $ 0Q�69   58      U� 59      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�5:        $ 0��6'   $	 250Q�63     5;      $ 0:0:0.5��6'   $ 0Q�69   5<      5=      5>      	 � Triggers	 5?      :� 5@   
   
 :� RoutedEvent$
 ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5A      �� #��[  6   5B      :� 5C   
   $
 ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5D      �� -   5         ��Name$ CloseMenu_BeginStoryboard��5D      #��[ 6A   5E      .��5G      � ���	#FF3580BF.+�5H   
   �� -   5         ��Name$ StackPanelMenu��5H      $	��250��6-   $
��Left=�69   $��
-250 0 0 0q�6T    J� RenderTransformOrigin$ 0.5,0.5&�6h   z�5I      V� 5J      .~�5K      �� �� 5L      �� 5M      T� 5N      5O      .+�5Q      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   $	��100��6J   $��Center=�6W   .+�5R      �� -   5         ��Name$ ButtonAtras��5R       0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6.   $��0q�6�   $��50��6�   $��50��6�   $��10q�6�   ��6t   Z� ��6�   Z� .��5S      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ KeyboardReturn=�6.   $��40��6D   $��40��6O   5T      �� 5U      -   5        $ button��5U      #��[ 6)   $��0q�6�   $��80��6�   $��80��6�   $��10q�6�   $ 0.5,0.5&�6�   ��6o   Z� z�5V      V� 5W      .~�5X      �� �� 5Y      �� 5Z      T� 5[      5\      ��5^      �� 5_       �� ImageSource$ /Imagenes/turismo.ico��6%    j� Stretch$ Uniform=�6I   5a      �� 5b      #��[ 6   $��0q�6�   $��50��6�   $��50��6�   $��10q�6�   ��6_   Z� ��6u   Z� .��5c        $ InformationOutline=�6.   $��40��6H   $��40��6S   5d      5e      �� 5f      .@�5g      �� -   5         ��Name$ listViewItem��5g      $��60��65   $ 0.5,0.5&�6A   z�5h      V� 5i      .~�5j      �� �� 5k      �� 5l      T� 5m      5n      .��5p      �� $ 
Horizontal=�6!   $
��10 0q�6:   .+�5q        $	 Add=�62   $��30��6=   $��30��6H   $��Center=�6T   $��5q�6o   �� 5r      -   5        $ ButtonAgregarSE��5r   !   $	��143��6:   $��32��6F   $��0q�6R   ��6^   Z� ��6t   Z� .��5s      �� $��Agregar Servicio Extra��6(   $��Center=�6F   $	��143��6a   $ 0.518,0.488&�6m   5t      5u      5v      �� 5w      -   5        $ listViewItem1��5w      $��60��66   $ 0.5,0.5&�6B   z�5x      V� 5y      .~�5z      �� �� 5{      �� 5|      T� 5}      5~      .��5�      �� $ 
Horizontal=�6!   $
��10 0q�6:   .+�5�        $ 
ListStatus=�62   $��30��6D   $��30��6O   $��Center=�6[   $��5q�6v   �� 5�      -   5        $ ButtonListarSE��5�   !   $	��154��69   $��30��6E   $��0q�6Q   ��6]   Z� ��6s   Z� .��5�      �� $��Listar Servicio Extra��6(   $��Center=�6E   $	��130��6`   $ 0.518,0.488&�6l   5�      5�      5�      5�      5�      � 5�   
   -	   5         �Name$ GridMain��5�      ���	#FFFBFBFB$
��1024��68   $ 0.5,0.5&�6E   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�       � ColumnDefinitions 5�      �� 5�      $��* �6#   �� 5�      $	��250 �6#   .+�5�      � $��1��6   ���	#FF3580BF.+�5�      �� $	��150��6   $	��Top=�6%   $��/Imagenes/back.jpg��6=   $��UniformToFill=�6Y   A� 5�      $	��151��6   $	��188��6'   $	��Top=�63   $��Right=�6K   $��	0,49,20,0q�6g   
���������5�      �� 5�      $ /Imagenes/turismo.ico��6%   $ Uniform=�6I   5�      �� 5�      $�� ��6   
�������$��28(�67   $��Nirmala UI Semilight)�6E   $��10 100q�6g   $	��Top=�6w   �� 5�      $��0 150q�6   .+�5�      � $��60��6   $��
20 50 20 0q�6'    5�      �� 5�      $��* �6/   �� 5�      $��* �6/    � RowDefinitions 5�      �� 5�      $��30 �6,   �� 5�      $��30 �6,   .+�5�      �� $��	FOLLOWERS��6$   $��Bottom=�65   ���	#FFFBFBFB$��5,0,5,5q�6g   �� 5�      $
��1.5K��6$   $	��Top=�60   ���	#FFFBFBFB$��1��6_   $
��10 0q�6l   �� 5�      $��	FOLLOWING��6$   $��Bottom=�65   ���	#FFFBFBFB$��5,0,5,5q�6g   $��1��6x   �� 5�      $
��2.3K��6$   $	��Top=�60   ���	#FFFBFBFB$��1��6_   $
��10 0q�6l   $��1��6z   5�      �� 5�      $
��Wrap=�6    $��10q�64   ���	#FFFBFBFB$��14(�6W   VTEstimado administrador, debe llenar los datos para ser registrado de manera exitosa.6�   5�      5�      � 5�      .+�5�      �� -
   5        $ ButtonCloseMenu��5�      #��[ 62   $��30��6x   $��30��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��5q�6�   $y�	Collapsed=�6$  ��6�   Z� ��6�   Z� .��5�        $
 Menu=�6.   ���	#FF3580BF6:   5�      �� 5�      -   5        $ ButtonOpenMenu��5�      #��[ 61   $��30��6w   $��30��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��5q�6�   ��6�   Z� ��6�   Z� .��5�        $
 Menu=�6.   ���	#FF3580BF6:   5�      5�      � 5�      $
��Left=�6   $	��392��6.   $��	62,52,0,0q�6;   $	��Top=�6N   $	��664��6f   ���	#FFF5F4F4.+�5�      �� -   5         ��Name$ 
lbl_nombre��5�      $��Nombre:��6,   $
��Left=�6>   $��	94,47,0,0q�6Y   $	��Top=�6l   ���	#DD0000006�   �� 5�      -   5        $ 
lbl_precio��5�      $��Precio:��6,   $
��Left=�6>   $��
371,47,0,0q�6Y   $	��Top=�6m   ���	#DD0000006�   �� 5�      -   5        $ lbl_descripcion��5�      $��Descripción:��61   $
��Left=�6H   $��
94,178,0,0q�6c   $	��Top=�6w   ���	#DD0000006�   �� 5�      -   5         ��Name$ 
txt_nombre��5�      $
��Left=�6.   $��23��6I   $��
155,51,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $	��120��6�   ���	#890000006�   �� 5�      -   5        $ 
txt_precio��5�      $
��Left=�6.   $��23��6I   $��
421,51,0,0q�6U   $
 Wrap=�6i   $	��Top=�6}   $	��120��6�   ���	#890000006�   �� 5�      -   5        $ txt_descripcion��5�      $
��Left=�63   $��65��6N   $��173,182,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $	��368��6�   ���	#890000006�   5�      � 5�      $��
-2,492,5,0q�6   ���	#FFFBFBFB.+�5�      �� -   5        $ btn_registrar��5�      $��	Registrar��60   $��
333,21,0,0q�6D   $��40��6X   $	��Top=�6d   $
��Left=�6|   $	��130��6�   6�   5�      5�      �� 5�   
   $ 
Horizontal=�6   $	��Top=�6.   $��40��6F   $��Right=�6R   $��10q�6n   .+�5�      �� #��[ 6   $��30��6[   $��30��6f   $��0q�6r   ��6~   Z� ��6�   Z� .��5�        $
 Bell=�6*   5�      �� 5�      -   5        $ ButtonClose��5�      #��[ 6*   $��30��6p   $��30��6{   $��0q�6�   ��6�   Z� ��6�   Z� .��5�        $ Power=�6*   5�      5�      5�      5�      