using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace AsynchronousProgramming
{
    public class WatermarkTextBehavior : Behavior<TextBox>
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(WatermarkTextBehavior),
                new FrameworkPropertyMetadata(string.Empty));

        public static readonly DependencyPropertyKey IsWatermarkedPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly("IsWatermarked", typeof(bool), typeof(WatermarkTextBehavior),
                                new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty IsWatermarkedProperty = IsWatermarkedPropertyKey.DependencyProperty;

        public bool IsWatermarked
        {
            get
            {
                return GetIsWatermarked(AssociatedObject);
            }
            private set
            {
                AssociatedObject.SetValue(IsWatermarkedPropertyKey, value);
            }

        }
        public string Text
        {
            get
            {
                return (string)base.GetValue(TextProperty);
            }

            set
            {
                base.SetValue(TextProperty, value);
            }

        }
        public static bool GetIsWatermarked(TextBox tb)
        {
            return (bool)tb.GetValue(IsWatermarkedProperty);
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += OnGotFocus;
            AssociatedObject.LostFocus += OnLostFocus;
            OnLostFocus(null,null);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.GotFocus -= OnGotFocus;
            AssociatedObject.LostFocus -= OnLostFocus;
        }

        private void OnLostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(AssociatedObject.Text))
            {
                AssociatedObject.Text = this.Text;
                IsWatermarked = true;
            }
        }

        private void OnGotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.Compare(AssociatedObject.Text, this.Text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                AssociatedObject.Text = string.Empty;
                IsWatermarked = false;
            }
        }
    }
}
