   M S B A M L   `   `   `  ����G  CSelaResortUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:SelaResortUI.BindingUtilitiesSelaResortUI.BindingUtilities  5      .    (SelaResortUI.Views.EmployeesSetupControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9l+clr-namespace:SelaResortUI.BindingUtilities     5        � 	Resources  5	      F  @SelaResortUI.BindingUtilities.EmployeeStringToEnumValueConverter   enumConverter��%   &	          5
   
   6/   5      .��5      � -   5        $��empgrid��5       � ColumnDefinitions 5   
   �� 5      $
��259* �6   �� 5      $
��125* �6   .+�5   
   �� -   5         ��Name$ 
empListBox��5      $
��Left=�6&   $	��348��6A   $	��Top=�6N   $	��250��6f   $��1��6r   ��6�   ��  �� Path$ 	Employees��� 5   
   -   5         ��Name$ fnameBox��5      $
��Left=�6$   $��23��6?    �� TextWrapping$
 Wrap=�6K   $	��Top=�6_   $	��138��6w   $��
114,41,0,0q�6�   ��6�   �� $ EmployeeObject.FirstName� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��
First Name��6   $
��Left=�6%   $��5,41,0,0q�6@   $	��Top=�6R   $	��109��6j   $��Miriam)�6v   $��13(�6�   $
��Bold"�6�   �� 5   
   -   5        $ lnameBox��5      $
��Left=�6$   $��23��6?   $
 Wrap=�6K   $	��Top=�6_   $	��138��6w   $��
114,69,0,0q�6�   ��6�   �� $ EmployeeObject.LastName�$ TwoWay=�$ PropertyChanged=��� 5   
   $��	Last Name��6   $
��Left=�6$   $��5,69,0,0q�6?   $	��Top=�6Q   $	��109��6i   $��Miriam)�6u   $��13(�6�   $
��Bold"�6�   �� 5   
   $��Position��6   $
��Left=�6#   $��5,97,0,0q�6>   $	��Top=�6P   $	��109��6h   $��Miriam)�6t   $��13(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ positionCBox��5      $
��Left=�6)   $��
114,92,0,0q�6D   $	��Top=�6X   $	��138��6p   ��6|   �� *	Positions+	 �� SelectedIndex	 6�   �� $ EmployeeObject.Position�$ TwoWay=�
 �� 	Converter#
 [  �� 5   
   $��
Start Date��6   $
��Left=�6%   $��	5,211,0,0q�6@   $	��Top=�6S   $	��109��6k   $��Miriam)�6w   $��13(�6�   $
��Bold"�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ sDateCalendar��5      $
��Left=�6-   $��114,211,0,0q�6H   $	��Top=�6]      SelectedDate 6u   �� $ EmployeeObject.HireDate�$ TwoWay=�$ PropertyChanged=��� 5   
   -   5         ��Name$ editBtn��5      $
��Edit��6"   $
��Left=�61   $��	0,353,0,0q�6L   $	��Top=�6_   $	��107��6w   $��1��6�   $��33��6�   ��5      �� 5       �� Triggers 5      �� 5       �� Binding 6&   ��  �� ElementName$ 
empListBox��$ SelectedIndex� �� Value -16e   .a�5      ��  �� Property � {� �� Value .  6A   5       5"      5$      �� 5%   
   -   5        $ 	deleteBtn��5%      $��Delete��6$   $
��Left=�65   $��143,353,0,0q�6P   $	��Top=�6e   $	��107��6}   $��1��6�   $��33��6�   ��5&      �� 5'       5(      �� 5)       6&   �� $ 
empListBox��$ SelectedIndex� -16e   .a�5*      ��  � {� .  6A   5+      5-      5/      �� 50   
   -	   5        $ addBtn��50      $	��Add��6!   $
��Left=�6/   $��114,353,0,0q�6J   $	��Top=�6_   $	��107��6w   $��33��6�   ��51      �� 52       53      �� 54       6&   �� *	IsEditing+ True6D   .a�55      ��  � y�$ Hidden=�6B   56      �� 57       6&   �� *	IsEditing+	 False6D   .a�58      ��  � y�$ Visible=�6B   59      5;      5=      �� 5>   
   -
   5        $ saveBtn��5>      $
��Save��6"   $
��Left=�61   $��114,353,0,0q�6L   $	��Top=�6a   $	��107��6y   $��33��6�   ��5?      �� 5@       5A      �� 5B       6&   �� *	IsEditing+ True6D   .a�5C      ��  � y�$ Visible=�6B   5D      �� 5E       6&   �� *	IsEditing+	 False6D   .a�5F      ��  � y�$ Hidden=�6B   5G      5I      5K      �� 5L   
   -   5        $ emailBox��5L      $
��Left=�6$   $��23��6?   $
 Wrap=�6K   $	��Top=�6_   $	��138��6w   $��114,124,0,0q�6�   ��6�   �� $ EmployeeObject.Email��� 5M   
   $��Email��6   $
��Left=�6    $��	5,124,0,0q�6;   $	��Top=�6N   $	��109��6f   $��Miriam)�6r   $��13(�6�   $
��Bold"�6�   $��23��6�   G� 5N   
   -   5         G�Name$ 	passwdBox��5N      $
��Left=�6)   $��23��6D   $	��Top=�6P   $	��138��6h   $��114,152,0,0q�6t   �� 5O   
   $��Password��6   $
��Left=�6#   $��	5,152,0,0q�6>   $	��Top=�6Q   $	��109��6i   $��Miriam)�6u   $��13(�6�   $
��Bold"�6�   �� 5P   
   -   5        $ cfrmEmailBox��5P      $
��Left=�6(   $��23��6C   $
 Wrap=�6O   $	��Top=�6c   $	��138��6{   $��375,124,0,0q�6�   ��6�   �� $! EmployeeObject.ConfirmEmail��� 5Q   
   $��Confirm Email��6   $
��Left=�6(   $��257,124,0,0q�6C   $	��Top=�6X   $	��113��6p   $��Miriam)�6|   $��13(�6�   $
��Bold"�6�   $��23��6�   G� 5R   
   -   5        $ cfrmPasswdBox��5R      $
��Left=�6-   $��23��6H   $	��Top=�6T   $	��137��6l   $��376,152,0,0q�6x   �� 5S   
   $��Confirm Password��6   $
��Left=�6+   $��257,152,0,0q�6F   $	��Top=�6[   $	��114��6s   $��Miriam)�6   $��13(�6�   $
��Bold"�6�   �� 5T   
   -   5         ��Name$ errBlock��5T      $
��Left=�6&   $	��166��6A   $��306,182,0,0q�6N   $
��Wrap=�6c   $	��Top=�6w   $	��202��6�   
���  ����6�   �� *Error+�� 5U   
   $��
Birth Date��6   $
��Left=�6%   $��	5,182,0,0q�6@   $	��Top=�6S   $	��109��6k   $��Miriam)�6w   $��13(�6�   $
��Bold"�6�     5V   
   -   5        $ bDate��5V      $
��Left=�6%   $��114,182,0,0q�6@   $	��Top=�6U    6m   �� *EmployeeObject.BirthDate+$ TwoWay=�$ PropertyChanged=�5X      5Y      