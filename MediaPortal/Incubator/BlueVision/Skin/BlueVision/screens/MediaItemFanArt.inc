<?xml version="1.0" encoding="utf-8"?>
<Grid
  xmlns="www.team-mediaportal.com/2008/mpf/directx"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  xmlns:fanart="clr-namespace:MediaPortal.Extensions.UserServices.FanArtService.Client;assembly=FanArtService.Client"
  xmlns:media="clr-namespace:MediaPortal.UiComponents.Media.Models.AspectWrappers;assembly=Media"
  x:Name="MediaItemDetails"
  Width="720" Height="560"
  Margin="-100,5,-15,17"
  OpacityMask="{ThemeResource HomeTileOpacityBrush}">
  <!-- Rounded corners are applied by OpacityMask -->

  <Grid.Resources>
    <fanart:FanArtImageSourceConverter x:Key="FanArtImageSourceConverter"/>
  </Grid.Resources>
  <Grid.ColumnDefinitions>
    <ColumnDefinition Width="*"/>
  </Grid.ColumnDefinitions>
  <Grid.RowDefinitions>
    <RowDefinition Height="*"/>
  </Grid.RowDefinitions>

  <!-- Image -->
  <Image Grid.Column="0" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Stretch="Fill" Margin="0,0,0,0"
      Source="{Binding Source={StaticResource FanArtBackgroundModel}, Path=ImageSource, Converter={StaticResource FanArtImageSourceConverter}, ConverterParameter=FanArt;720;560}"   
      FallbackSource="{Binding Source={StaticResource FanArtBackgroundModel},Path=MediaItem}">
  </Image>
     
    <!--Image.OpacityMask>
        <LinearGradientBrush StartPoint="0.6,0" EndPoint="0.9,0">
          <GradientStop Offset="0.0" Color="#60000000" />
          <GradientStop Offset="1.0" Color="#00000000" />
        </LinearGradientBrush>
    </Image.OpacityMask>
  </Image-->

  <!-- Darkened band -->
  <!--Rectangle Grid.Row="1" Grid.Column="0" Fill="#FF000000" Opacity="0.749"
             HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Margin="0,0,0,0"
             IsVisible="{Binding Source={StaticResource FanArtBackgroundModel}, Path=SelectedItem,Converter={StaticResource ReferenceToBoolConverter}}"/-->

  <!-- Item label -->
  <!--Label Grid.Row="1" Grid.Column="0" x:Name="ItemLabel" HorizontalAlignment="Center" VerticalAlignment="Center"  Content="{Binding Source={StaticResource FanArtBackgroundModel}, Path=SimpleTitle}"
         Color="{ThemeResource TextColor}"/-->
</Grid>
