   M S B A M L   `   `   `  ����H  DTurismoRealFF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:TurismoRealFF.Vistas.Mantenedores.Inventario,TurismoRealFF.Vistas.Mantenedores.Inventario  5   	   C    =TurismoRealFF.Vistas.Mantenedores.Inventario.ListarInventario   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:TurismoRealFF.Vistas.Mantenedores.Inventario     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  listarProducto��5   	   $	��600��5   R   $
��1024��6_    � WindowStyle$
 None=�6l    � WindowStartupLocation$ CenterScreen=�6   '  !System.Windows.Shell.WindowChrome   WindowChrome 5	        5
   
      CaptionHeight$ 0Q�6    � 	Resources 5         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  	CloseMenu��%�  &	        &	 �    �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $		 250Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $	 50Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $		 250Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ button��6�   .\�5        $ 0��6'   $	 0Q�63     5      $ 0:0:0.5��6'   $	 0Q�69     5      $ 0:0:1.5��6'   $	 1Q�69   5      U� 5       $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ button��6�   .\�5!        $ 0��6'   $	 0Q�63     5"      $ 0:0:0.5��6'   $	 0Q�69     5#      $ 0:0:1.5��6'   $	 1Q�69   5$      5%      �� 5&   
   .��5'      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMain��6�   .\�5(        $ 0��6'   $		 250Q�63     5)      $ 0:0:0.5��6'   $	 0Q�69   5*      U� 5+      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ GridMain��6�   .\�5,        $ 0��6'   $	 50Q�63     5-      $ 0:0:0.5��6'   $	 0Q�69   5.      U� 5/      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ StackPanelMenu��6�   .\�50        $ 0��6'   $		 250Q�63     51      $ 0:0:0.5��6'   $	 0Q�69   52      53      54      
 � Triggers
 55      :� 56   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�57      �� #��[  6   58      :� 59   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5:      �� -   5         ��Name$ CloseMenu_BeginStoryboard��5:      #��[ 6A   5;      .��5=      � ���	#FF3580BF.+�5>   
   �� -   5         ��Name$ StackPanelMenu��5>      $	��250��6-   $
��Left=�69   $��
-250 0 0 0q�6T    J� RenderTransformOrigin$ 0.5,0.5&�6h   z�5?      V� 5@      .~�5A      �� �� 5B      �� 5C      T� 5D      5E      .+�5G      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   $	��100��6J   $��Center=�6W   .+�5H      �� -   5         ��Name$ ButtonAtras��5H       0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6.   $��0q�6�   $��50��6�   $��50��6�   $��10q�6�   ��6t   Z� ��6�   Z� .��5I      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ KeyboardReturn=�6.   $��40��6D   $��40��6O   5J      �� 5K      -   5        $ button��5K      #��[ 6)   $��0q�6�   $��80��6�   $��80��6�   $��10q�6�   $ 0.5,0.5&�6�   ��6o   Z� z�5L      V� 5M      .~�5N      �� �� 5O      �� 5P      T� 5Q      5R      ��5T      �� 5U       �� ImageSource$ /Imagenes/turismo.ico��6%    j� Stretch$ Uniform=�6I   5W      �� 5X      #��[ 6   $��0q�6�   $��50��6�   $��50��6�   $��10q�6�   ��6_   Z� ��6u   Z� .��5Y        $ InformationOutline=�6.   $��40��6H   $��40��6S   5Z      5[      �� 5\      5_      5`      � 5b   
   -   5         �Name$ GridMain��5b      ���	#FFFBFBFB$
��1024��68   $ 0.5,0.5&�6E   z�5c      V� 5d      .~�5e      �� �� 5f      �� 5g      T� 5h      5i       � ColumnDefinitions 5k      �� 5l      $��* �6#   �� 5m      $	��250 �6#   .+�5p      � $��1��6   ���	#FF3580BF.+�5q      �� $	��150��6   $	��Top=�6%   $��/Imagenes/back.jpg��6=   $��UniformToFill=�6Y   A� 5r      $	��151��6   $	��188��6'   $	��Top=�63   $��Right=�6K   $��	0,49,20,0q�6g   
���������5s      �� 5t      $ /Imagenes/turismo.ico��6%   $ Uniform=�6I   5v      �� 5w      $�� ��6   
�������$��28(�67   $��Nirmala UI Semilight)�6E   $��10 100q�6g   $	��Top=�6w   �� 5x      $��0 150q�6   .+�5y      � $��60��6   $��
20 50 20 0q�6'    5z      �� 5{      $��* �6/   �� 5|      $��* �6/    � RowDefinitions 5~      �� 5      $��30 �6,   �� 5�      $��30 �6,   .+�5�      �� $��	FOLLOWERS��6$   $��Bottom=�65   ���	#FFFBFBFB$��5,0,5,5q�6g   �� 5�      $
��1.5K��6$   $	��Top=�60   ���	#FFFBFBFB$��1��6_   $
��10 0q�6l   �� 5�      $��	FOLLOWING��6$   $��Bottom=�65   ���	#FFFBFBFB$��5,0,5,5q�6g   $��1��6x   �� 5�      $
��2.3K��6$   $	��Top=�60   ���	#FFFBFBFB$��1��6_   $
��10 0q�6l   $��1��6z   5�      �� 5�      $
��Wrap=�6    $��10q�64   ���	#FFFBFBFB$��14(�6W   ��Estimado administrador, debe filtrar por recinto y departamento luego presionar buscar para ser cargados en la grilla. Abajo de la grilla puedes agregar un nuevo producto, debes ingresar todos los datos correspondientes para ser ingresados correctamente.6e  5�      5�      � 5�      .+�5�      � $��0,0,731,555q�6   .+�5�      �� -   5        $ ButtonCloseMenu��5�      #��[ 66   $��30��6|   $��30��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��5q�6�   $y�	Collapsed=�6(  ��6�   Z� ��6�   Z� .��5�        $
 Menu=�62   ���	#FF3580BF6>   5�      �� 5�      -   5        $ ButtonOpenMenu��5�      #��[ 65   $��30��6{   $��30��6�   $��0q�6�   $	��Top=�6�   $
��Left=�6�   $��5q�6�   ��6�   Z� ��6�   Z� .��5�        $
 Menu=�62   ���	#FF3580BF6>   5�      5�      � 5�      $
��Left=�6   $	��392��62   $��	63,40,0,0q�6?   $	��Top=�6R   $	��664��6j   ���	#FFF5F4F4.+�5�      &   System.Windows.Controls.DataGrid  -	   5          Name$ dt_lista��5�      $
��Left=�61   $	��171��6L   $��	47,88,0,0q�6Y   $	��Top=�6l   $	��541��6�      EnableRowVirtualization .   � ContextMenu 5�      �� 5�       �� ItemBindingGroup 5�   "   &   System.Windows.Data.BindingGroup  5�   &   !   ValidatesOnNotifyDataError .  63    J� 	CacheMode 5�   "   &   System.Windows.Media.BitmapCache  5�   &   5�      5�      �� 5�      -
   5         ��Name$ lbl_recinto��5�      $��Recinto:��61   $
��Left=�6D   $��	47,12,0,0q�6_   $	��Top=�6r   ���	#DD0000006�   �� 5�      -   5        $ 	lbl_depto��5�      $��Departamento:��6/   $
��Left=�6G   $��
203,12,0,0q�6b   $	��Top=�6v   ���	#DD0000006�   �� 5�      -   5         ��Name$ cmb_recinto��5�      $
��Left=�64   $��	47,43,0,0q�6O   $	��Top=�6b   $	��120��6z   ���	#890000006�   �� 5�      -   5        $ 	cmb_depto��5�      $
��Left=�62   $��
211,43,0,0q�6M   $	��Top=�6a   $	��120��6y   ���	#890000006�   �� 5�      -   5        $ 
btn_buscar��5�      $��Buscar��61   $
��Left=�6B   $��
459,27,0,0q�6]   $	��Top=�6q   $	��126��6�   $��38��6�   6�   �� 5�      -   5        $ 
lbl_nombre��5�      $��Nombre Producto:��60   $
��Left=�6K   $��
47,264,0,0q�6f   $	��Top=�6z   ���	#DD0000006�   �� 5�      -   5          ��Name$  
txt_nombre��5�      $
��Left=�62   $��24��6M   $��
47,295,0,0q�6Y   ! �� TextWrapping$
! Wrap=�6m   $	��Top=�6�   $	��120��6�   ���	#890000006�   �� 5�      -   5        $ lbl_categoria��5�      $��Categoría:��63   $
��Left=�6H   $��
47,324,0,0q�6c   $	��Top=�6w   ���	#DD0000006�   �� 5�      -   5        $ cmb_categoria��5�      $
��Left=�66   $��
47,355,0,0q�6Q   $	��Top=�6e   $	��120��6}   ���	#890000006�   �� 5�      -   5        $ 	lbl_color��5�      $��Color:��6/   $
��Left=�6@   $��211,264,0,0q�6[   $	��Top=�6p   ���	#DD0000006�   �� 5�      -   5        $  	txt_color��5�      $
��Left=�61   $��23��6L   $��211,296,0,0q�6X   $
! Wrap=�6m   $	��Top=�6�   $	��120��6�   ���	#890000006�   �� 5�      -   5        $ lbl_peso��5�      $��Peso:��6.   $
��Left=�6>   $��211,324,0,0q�6Y   $	��Top=�6n   ���	#DD0000006�   �� 5�      -   5        $  txt_peso��5�      $
��Left=�60   $��23��6K   $��211,354,0,0q�6W   $
! Wrap=�6l   $	��Top=�6�   $	��120��6�   ���	#890000006�   �� 5�      -   5        $ lbl_dimension��5�      $��Dimensión:��63   $
��Left=�6H   $��376,264,0,0q�6c   $	��Top=�6x   ���	#DD0000006�   �� 5�      -   5        $  txt_dimension��5�      $
��Left=�65   $��23��6P   $��376,295,0,0q�6\   $
! Wrap=�6q   $	��Top=�6�   $	��120��6�   ���	#890000006�   �� 5�      -   5        $ 
lbl_precio��5�      $��Precio:��60   $
��Left=�6B   $��376,324,0,0q�6]   $	��Top=�6r   ���	#DD0000006�   �� 5�      -   5        $  
txt_precio��5�      $
��Left=�62   $��23��6M   $��376,354,0,0q�6Y   $
! Wrap=�6n   $	��Top=�6�   $	��120��6�   ���	#890000006�   �� 5�      -   5        $  txt_inventarioId��5�      $
��Left=�68   $��23��6S   $��616,296,0,0q�6_   $
! Wrap=�6t   $	��Top=�6�   $��38��6�   $y�Hidden=�6�   5�      � 5�      $��80,492,47,0q�6   ���	#FFFBFBFB.+�5�      �� -   5        $ btn_ingresar��5�      $��Ingresar��63   $��
250,33,0,0q�6F   $��40��6Z   $	��Top=�6f   $
��Left=�6~   $	��130��6�   6�   5�      5�      5�      �� 5�   
   $ 
Horizontal=�6   $	��Top=�6.   $��40��6F   $��Right=�6R   $��10q�6n   .+�5�      �� #��[ 6   $��30��6[   $��30��6f   $��0q�6r   ��6~   Z� ��6�   Z� .��5�        $
 Bell=�6*   5�      �� 5�      -   5        $ ButtonClose��5�      #��[ 6*   $��30��6p   $��30��6{   $��0q�6�   ��6�   Z� ��6�   Z� .��5�        $ Power=�6*   5�      5�      5�      5�      