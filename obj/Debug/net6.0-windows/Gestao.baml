   M S B A M L   `   `   `  ����H  DRegistroPonto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RegistroPontoRegistroPonto  5   	       RegistroPonto.Gestao   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -localclr-namespace:RegistroPonto     5   	     � Title$  Tela de Gestão��5   	   $	��450��6    $	��800��6-   ���#F0FFFF.��5      � .+�5   
   �� -   5        $��Deslogar��5      $
��Left=�5      $	��Top=�6,   $��20q�5	      5
      �� 5   
   -   5        $��Folha Ponto��5      $��Right=�6F   $	��Top=�6b   $��20q�6z   �� 5   
   $��Tela de Cadastro��6   $��Center=�6,   $	��Top=�6I   $��0,20,0,0q�6a   $
��Bold"�6s   �� 5   
   $��20,60,20,110q�6g   ��6   �� *Funcionarios+ �� SelectedItem 67   �� *FuncionarioSelecionado+��5      �� 5      .R�5      �  � ColumnDefinitions 5      �� 5      $��50 �6/   �� 5      $	��300 �6/   �� 5      $	��200 �6/   �� 5      $	��100 �6/   .+�5      �� $��Center=�68   $��0��6S   $��5q�6c   ��6$   �� *Id+6c   �� 5      $��Center=�6:   $��1��6U   $��5q�6e   ��6$   �� *Nome+6e   �� 5      $��Center=�6;   $��2��6V   $��5q�6f   ��6$   �� *Cargo+6f   �� 5      $��50��6<   $��50��6G   $��5q�6S   $��3��6^   ��6    �� *
FotoPath+6^   5       5!      5#      �� 5%   
   $��Nome:��6   $
��Left=�6    $��Bottom=�6;   $��	20,0,0,70q�6V   �� 5&   
   -   5         ��Name$ NomeTextBox��5&      $
��Left=�6q   $	��200��6�   $��Bottom=�6�   $��	70,0,0,70q�6�   ��6'   �� *NovoFuncionarioNome+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5)   
   $��Cargo:��6   $
��Left=�6!   $��Bottom=�6<   $��	20,0,0,40q�6W   �� 5*   
   -   5        $ CargoTextBox��5*      $
��Left=�6s   $	��200��6�   $��Bottom=�6�   $��	70,0,0,40q�6�   ��6(   �� *NovoFuncionarioCargo+$ PropertyChanged=�6�   �� 5-   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��Bottom=�6J   $��0,0,0,30q�6e   .+�5.      �� -   5         ��Name$ 	FotoImage��5.      $��50��6'   $��50��62   $��5q�6Z   ��6>   �� *
FotoPath+6Z   �� 5/      -   5        $��Selecionar Foto��5/      $��5q�6/   6:   �� 50      $��	Cadastrar��6   $��5q�6Y   ��6)   �� *CadastrarFuncionarioCommand+6Y   �� 52      $��Excluir��6   $��5q�6U   ��6'   �� *ExcluirFuncionarioCommand+6U   54      55      56      