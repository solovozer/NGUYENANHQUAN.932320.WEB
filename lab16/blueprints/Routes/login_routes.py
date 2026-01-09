from flask import Blueprint, request, render_template, redirect, url_for
from blueprints.Forms import *

login_bp = Blueprint('login', __name__)

@login_bp.route('/Login')
def LoginRoute():
    if request.method =='POST': 
        i = 1
    elif request.method == 'GET':
        return render_template('Login/login.html')

@login_bp.route('/Register', methods = ['GET', 'POST'])
def RegisterRoute():
    form = RegisterForm()
    if form.validate_on_submit():
        return redirect(url_for('login.LoginRoute'))
    return render_template('Login/register.html', form=form)
