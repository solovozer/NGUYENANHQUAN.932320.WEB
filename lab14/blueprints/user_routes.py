from flask import Blueprint, render_template, request, jsonify
from blueprints.Forms import *

user_bp = Blueprint('user', __name__)

@user_bp.route('/')
def ControlsRoute():
    return render_template('Controls.html')

@user_bp.route('/TextBox', methods = ['GET', 'POST'])
def TextBoxRoute():
    form = TextBoxForm()
    if request.method == 'POST':
        return jsonify({'result': form.text.data})
    return render_template('Controls/TextBox.html', form = form)

@user_bp.route('/TextArea', methods = ['GET', 'POST'])
def TextAreaRoute():
    form = TextAreaForm()
    if request.method == 'POST':
        return jsonify({'result': form.text.data})
    return render_template('Controls/TextArea.html', form = form)

@user_bp.route('/CheckBox', methods = ['GET', 'POST'])
def CheckBoxRoute():
    form = CheckBoxForm()
    if request.method == 'POST':
        return jsonify({'result': form.IsSelected.data})
    return render_template('Controls/CheckBox.html', form = form)

@user_bp.route('/Radio', methods = ['GET', 'POST'])
def RadioRoute():
    form = RadioForm()
    if request.method == 'POST':
        return jsonify({'result': form.Months.data})
    return render_template('Controls/Radio.html', form = form)

@user_bp.route('/DropDownList', methods = ['GET', 'POST'])
def DropDownRoute():
    form = DropDownForm()
    if request.method == 'POST':
        return jsonify({'result': form.Months.data})
    return render_template('Controls/DropDownList.html', form = form)

@user_bp.route('/ListBox', methods = ['GET', 'POST'])
def ListBoxRoute():
    form = ListBoxForm()
    if request.method == 'POST':
        return jsonify({'result': form.Months.data})
    return render_template('Controls/ListBox.html', form = form)
