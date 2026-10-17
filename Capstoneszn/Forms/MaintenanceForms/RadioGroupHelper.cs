using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstoneszn.Forms.MaintenanceForms
{
    /// <summary>
    /// WinForms only makes radio buttons exclusive when they share the SAME
    /// parent container. Our forms put each radio in its own bordered panel
    /// (for the layout), so the designer treats every radio as its own group.
    /// Link() restores the "only one can be selected" behaviour in code,
    /// without changing the layout.
    /// </summary>
    public static class RadioGroupHelper
    {
        public static void Link(params RadioButton[] group)
        {
            foreach (RadioButton rb in group)
            {
                rb.CheckedChanged += (s, e) =>
                {
                    var selected = (RadioButton)s;
                    if (!selected.Checked) return;

                    foreach (RadioButton other in group)
                        if (other != selected)
                            other.Checked = false;
                };
            }
        }
    }
}
