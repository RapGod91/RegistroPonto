   M S B A M L   `   `   `  ����  RegistroPonto$    RegistroPonto.Views.FolhaPonto   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Folha de Ponto��5   	   $	��550��6    $	��800��6-   ���#F0FFFF � 	Resources 5         DataAusenteStyle �� 
TargetType �� Property �� Value��%T   &	        �� 5   
   " ��6)   .�5      ��  � ��
 �  ��6+   5	      5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   $��10q�6!   .+�5      �� $��Buscar por Nome:��6   $��Center=�6/   $
��Left=�6J   �� 5      -   5         ��Name$ NomeFuncionarioTextBox��5      $	��200��66   $��5q�6B   �� 5      -   5        $��Buscar��5      $��5q�6A   5      � 5   
   $��1��6    5      �� 5      $
��Auto �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5       $
��Auto �6#   �� 5!      $��* �6#   .+�5$      �� $��0��6   $��0��6&   $��Center=�66   .+�5%      �� -   5         ��Name$ FotoFuncionarioImage��5%      $	��150��66   $	��150��6B   $��10q�6O   �� 5&      $��ID do Funcionário:��6   �� 5'      -   5        	 ��Name$	 IdFuncionarioTextBlock��5'      $��10q�6<   �� 5(      $��Nome do Funcionário:��6   �� 5)      -   5        $	 NomeFuncionarioTextBlock��5)      $��10q�6>   �� 5*      $��Cargo do Funcionário:��6   �� 5+      -   5        $	 CargoFuncionarioTextBlock��5+      $��10q�6?   �� 5,      -   5        $	 DiasAusentesTextBlock��5,      $��10q�6;   #��[  6G   �� 5-      -   5        $��Fechar��5-      $
��Left=�5.      $	��Top=�6,   $��20q�5/      50      51      �� 53      -	   5        
 ��Name$
 RegistroPontoListView��53   E   $��0��6   $��1��6$   $��2��64    �� View 54      �� 55      .P�56      �� $��Registro��6)    �� Width$	 250��6e    �� DisplayMemberBinding 6;   �� *
Registro+6e   �� 57      $��Data Ausente��6)   $	 250��6?    �� CellTemplate 58      �� 59   "   .R�5:   &   �� #��[  6M   ��60   �� *DataAusente+6M   5;   #   5=      5>      5@      5A      5B      5C      