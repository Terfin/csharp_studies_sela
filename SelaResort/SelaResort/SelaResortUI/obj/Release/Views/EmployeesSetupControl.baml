   M S B A M L   `   `   `  ���� G  CSelaResortUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:SelaResortUI.BindingUtilitiesSelaResortUI.BindingUtilities  .    (SelaResortUI.Views.EmployeesSetupControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9l+clr-namespace:SelaResortUI.BindingUtilities       � 	Resources  F  @SelaResortUI.BindingUtilities.EmployeeStringToEnumValueConverter   enumConverter��%   &	          .��� -   $��empgrid�� � ColumnDefinitions �� $
��259* ��� $
��125* �.+��� -    ��Name$ 
empListBox��$
��Left=�$	��348��$	��Top=�$	��250��$��1������  �� Path$ 	Employees��� -    ��Name$ fnameBox��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��138��$��
114,41,0,0q����� $ EmployeeObject.FirstName� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��
First Name��$
��Left=�$��5,41,0,0q�$	��Top=�$	��109��$��Miriam)�$��13(�$
��Bold"��� -   $ lnameBox��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��138��$��
114,69,0,0q����� $ EmployeeObject.LastName�$ TwoWay=�$ PropertyChanged=��� $��	Last Name��$
��Left=�$��5,69,0,0q�$	��Top=�$	��109��$��Miriam)�$��13(�$
��Bold"��� $��Position��$
��Left=�$��5,97,0,0q�$	��Top=�$	��109��$��Miriam)�$��13(�$
��Bold"��� -    ��Name$ positionCBox��$
��Left=�$��
114,92,0,0q�$	��Top=�$	��138������ *	Positions+	 �� SelectedIndex	 �� $ EmployeeObject.Position�$ TwoWay=�
 �� 	Converter#
 [  �� $��
Start Date��$
��Left=�$��	5,211,0,0q�$	��Top=�$	��109��$��Miriam)�$��13(�$
��Bold"�(  "System.Windows.Controls.DatePicker  -     Name$ sDateCalendar��$
��Left=�$��114,211,0,0q�$	��Top=�   SelectedDate �� $ EmployeeObject.HireDate�$ TwoWay=�$ PropertyChanged=��� -    ��Name$ editBtn��$
��Edit��$
��Left=�$��	0,353,0,0q�$	��Top=�$	��107��$��1��$��33������  �� Triggers ��  �� Binding ��  �� ElementName$ 
empListBox��$ SelectedIndex� �� Value -1.a���  �� Property � {� �� Value .  �� -   $ 	deleteBtn��$��Delete��$
��Left=�$��143,353,0,0q�$	��Top=�$	��107��$��1��$��33������  ��  �� $ 
empListBox��$ SelectedIndex� -1.a���  � {� .  �� -	   $ addBtn��$	��Add��$
��Left=�$��114,353,0,0q�$	��Top=�$	��107��$��33������  ��  �� *	IsEditing+ True.a���  � y�$ Hidden=���  �� *	IsEditing+	 False.a���  � y�$ Visible=��� -
   $ saveBtn��$
��Save��$
��Left=�$��114,353,0,0q�$	��Top=�$	��107��$��33������  ��  �� *	IsEditing+ True.a���  � y�$ Visible=���  �� *	IsEditing+	 False.a���  � y�$ Hidden=��� -   $ emailBox��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��138��$��114,124,0,0q����� $ EmployeeObject.Email��� $��Email��$
��Left=�$��	5,124,0,0q�$	��Top=�$	��109��$��Miriam)�$��13(�$
��Bold"�$��23��G� -    G�Name$ 	passwdBox��$
��Left=�$��23��$	��Top=�$	��138��$��114,152,0,0q��� $��Password��$
��Left=�$��	5,152,0,0q�$	��Top=�$	��109��$��Miriam)�$��13(�$
��Bold"��� -   $ cfrmEmailBox��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��138��$��375,124,0,0q����� $! EmployeeObject.ConfirmEmail��� $��Confirm Email��$
��Left=�$��257,124,0,0q�$	��Top=�$	��113��$��Miriam)�$��13(�$
��Bold"�$��23��G� -   $ cfrmPasswdBox��$
��Left=�$��23��$	��Top=�$	��137��$��376,152,0,0q��� $��Confirm Password��$
��Left=�$��257,152,0,0q�$	��Top=�$	��114��$��Miriam)�$��13(�$
��Bold"��� -    ��Name$ errBlock��$
��Left=�$	��166��$��306,182,0,0q�$
��Wrap=�$	��Top=�$	��202��
���  ������ *Error+�� $��
Birth Date��$
��Left=�$��	5,182,0,0q�$	��Top=�$	��109��$��Miriam)�$��13(�$
��Bold"�  -   $ bDate��$
��Left=�$��114,182,0,0q�$	��Top=� �� *EmployeeObject.BirthDate+$ TwoWay=�$ PropertyChanged=�