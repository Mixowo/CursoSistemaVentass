using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Linq;

public static class FormManager
{
    private static readonly Dictionary<Type, Form> openForms = new Dictionary<Type, Form>();

    public static void ShowForm<T>(Func<T> formCreator) where T : Form
    {
        Type formType = typeof(T);

        // Si ya existe una instancia del formulario, lo trae al frente
        if (openForms.TryGetValue(formType, out Form existingForm) && !existingForm.IsDisposed)
        {
            existingForm.WindowState = FormWindowState.Normal;  // Restaura el formulario si estaba minimizado
            existingForm.BringToFront();                         // Lo trae al frente
            existingForm.Activate();                             // Lo enfoca
            return;
        }

        // Si el formulario no existe, lo crea y lo muestra
        T newForm = formCreator();
        newForm.FormClosed += (s, e) => openForms.Remove(formType); // Eliminar del diccionario cuando se cierra
        openForms[formType] = newForm;

        newForm.Show();  // Cambié ShowDialog por Show para permitir varios formularios abiertos
    }

    // Método para cerrar todos los formularios abiertos
    public static void CloseAllForms()
    {
        // Crear una lista de los formularios abiertos, haciendo una copia de los valores del diccionario
        var openFormsCopy = openForms.Values.ToList();

        foreach (var form in openFormsCopy)
        {
            form.Close();  // Cierra cada formulario
        }
        openForms.Clear();  // Limpia el diccionario después de cerrar los formularios
    }

}





