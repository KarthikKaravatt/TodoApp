
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.0.18.0
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace TodoApp {
    using System;
    using Terminal.Gui;
    
    
    public partial class MyView : Terminal.Gui.Window {
        
        private Terminal.Gui.Label label1;
        
        private Terminal.Gui.Button button1;
        
        private void InitializeComponent() {
            this.button1 = new Terminal.Gui.Button();
            this.label1 = new Terminal.Gui.Label();
            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill(0);
            this.X = 0;
            this.Y = 0;
            this.Modal = false;
            this.Text = "";
            this.Title = "Press Ctrl+Q to quit";
            this.label1.Width = Dim.Auto();
            this.label1.Height = 1;
            this.label1.X = Pos.Center();
            this.label1.Y = Pos.Center();
            this.label1.Data = "label1";
            this.label1.Text = "Hello World";
            this.Add(this.label1);
            this.button1.Width = Dim.Auto();
            this.button1.X = Pos.Center();
            this.button1.Y = Pos.Center() + 1;
            this.button1.Data = "button1";
            this.button1.Text = "Click Me";
            this.button1.IsDefault = false;
            this.Add(this.button1);
        }
    }
}
