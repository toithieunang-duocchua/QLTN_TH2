# Script để sửa các control Guna UI2 trong các file Designer
# Thay thế System.Windows.Forms controls bằng Guna.UI2.WinForms controls

$designerFiles = Get-ChildItem -Path "Forms" -Filter "*.Designer.cs" -Recurse

foreach ($file in $designerFiles) {
    Write-Host "Đang sửa file: $($file.FullName)"
    
    $content = Get-Content $file.FullName -Raw
    
    # Thay thế các khai báo control
    $content = $content -replace "new System\.Windows\.Forms\.Button\(\)", "new Guna.UI2.WinForms.Guna2Button()"
    $content = $content -replace "new System\.Windows\.Forms\.TextBox\(\)", "new Guna.UI2.WinForms.Guna2TextBox()"
    $content = $content -replace "new System\.Windows\.Forms\.ComboBox\(\)", "new Guna.UI2.WinForms.Guna2ComboBox()"
    $content = $content -replace "new System\.Windows\.Forms\.CheckBox\(\)", "new Guna.UI2.WinForms.Guna2CheckBox()"
    $content = $content -replace "new System\.Windows\.Forms\.RadioButton\(\)", "new Guna.UI2.WinForms.Guna2RadioButton()"
    $content = $content -replace "new System\.Windows\.Forms\.Label\(\)", "new Guna.UI2.WinForms.Guna2HtmlLabel()"
    $content = $content -replace "new System\.Windows\.Forms\.Panel\(\)", "new Guna.UI2.WinForms.Guna2Panel()"
    $content = $content -replace "new System\.Windows\.Forms\.GroupBox\(\)", "new Guna.UI2.WinForms.Guna2GroupBox()"
    
    # Thay thế các khai báo biến
    $content = $content -replace "private System\.Windows\.Forms\.Button", "private Guna.UI2.WinForms.Guna2Button"
    $content = $content -replace "private System\.Windows\.Forms\.TextBox", "private Guna.UI2.WinForms.Guna2TextBox"
    $content = $content -replace "private System\.Windows\.Forms\.ComboBox", "private Guna.UI2.WinForms.Guna2ComboBox"
    $content = $content -replace "private System\.Windows\.Forms\.CheckBox", "private Guna.UI2.WinForms.Guna2CheckBox"
    $content = $content -replace "private System\.Windows\.Forms\.RadioButton", "private Guna.UI2.WinForms.Guna2RadioButton"
    $content = $content -replace "private System\.Windows\.Forms\.Label", "private Guna.UI2.WinForms.Guna2HtmlLabel"
    $content = $content -replace "private System\.Windows\.Forms\.Panel", "private Guna.UI2.WinForms.Guna2Panel"
    $content = $content -replace "private System\.Windows\.Forms\.GroupBox", "private Guna.UI2.WinForms.Guna2GroupBox"
    
    # Thêm using directive nếu chưa có
    if ($content -notmatch "using Guna\.UI2\.WinForms;") {
        $content = $content -replace "(namespace QLTN\.Forms)", "using Guna.UI2.WinForms;`n`n$1"
    }
    
    Set-Content $file.FullName -Value $content -Encoding UTF8
    Write-Host "Đã sửa xong: $($file.Name)"
}

Write-Host "Hoàn thành việc sửa các file Designer!"

