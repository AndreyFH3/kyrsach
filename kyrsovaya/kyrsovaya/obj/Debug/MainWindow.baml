   M S B A M L   `   `   `  ����D  @kyrsovaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:kyrsovaya	kyrsovaya  5   	       kyrsovaya.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:kyrsovaya     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   
   $��Regular"�5
   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ Manual=�65    � 
ResizeMode$ NoResize=�6T    � WindowStyle$
 None=�6j   .��5      � ���#74250e � ColumnDefinitions 5   
   �� 5      $	��50  �6   �� 5      .+�5   
   � ���#140c12 � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��50 �6    �� 5      $��50 �6    �� 5      �� 5      $��50 �6    .+�5      �� -   5        $��50��5   B   $��50��6M   $��Right=�6Y   $��0,0,-0.4,0.4q�6u   ��6   Z� ��6+   Z� .��5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Home=�6*   5!      �� 5"      -   5        $��1��5"      $��50��6O   $��50��6Z   ��6"   Z� ��68   Z� .��5#        $ Magnify=�6*   5$      �� 5%      -   5        $��3��5%      $��Bottom=�6"   $��50��6k   $��50��6v   ��6>   Z� ��6T   Z� .��5&        $ Information=�6*   5'      �� 5(      -   5        $��4��5(      $��50��6O   $��50��6Z   ��6"   Z� ��68   Z� .��5)        $ Power=�6*   5*      5+      � 5,   
   $��1��6   .+�5-         kyrsovaya.opening  -   5        	  Name$	 openpage��5-      $��0,0,0.4,-0.4q�6.   �� 5.      -   5        
 ��Name$	
 btn��5.      $��Найти событие��6"   $��Comic Sans MS)�6:   $��300, 350, 300, 50q�6U   $��50��6p   ���#a55248���#a552486�   5/         kyrsovaya.SecondPage  50   
   -   5          Name$ Search��50      $
��Left=�6+   $	��Top=�6F   $	��450��6^   $	��750��6k   $��1��6w   $��760,0,-760,0q�6�      kyrsovaya.ThirdPage  51   
   -   5          Name$ Information��51      $
��Left=�6/   $��0,455,0,-460q�6J   $	��Top=�6`   $	��455��6x   $	��750��6�   $��1��6�   52      53      