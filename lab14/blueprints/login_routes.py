from flask import Blueprint, request, render_template, redirect, url_for, session, jsonify
from blueprints.Forms import *
import random

login_bp = Blueprint('login', __name__)

@login_bp.route('/SignUp', methods=['GET', 'POST'])
def SignUp():
    form = SignUpForm()
    if form.validate_on_submit():
        session['login'] = {
            'firstname' : form.firstname.data,
            'lastname' : form.lastname.data,
            'birthday' : f'{form.day.data}  {form.month.data} {form.year.data}', 
            'gender' : form.gender.data,
            'email' : form.email.data,
            'password' : form.password.data,
        }
        return redirect(url_for('login.SignUpCredentials'))
    return render_template('Mockups/SignUp.html', form=form)

@login_bp.route('/SignUpCredentials')
def SignUpCredentials():
    data = session.get('login')
    return render_template('Mockups/SignUpCredentials.html', data = data)

@login_bp.route('/Reset', methods = ['GET', 'POST'])
def ResetPassword():
    action = request.form.get("action")
    if request.method == "GET":
        form = ResetForm()
        return render_template('Mockups/Reset.html', form=form, rightcode = session.get("email_code"))
    elif request.method == "POST":
        if action == "send_code":
            code = str(random.randint(100000, 999999))
            session["email_code"] = code
            return jsonify(success=True)
        if action == "verify_code":
            if request.form.get("code") == session.get("email_code"):
                return jsonify(success=True)
        return jsonify(success=False)
        