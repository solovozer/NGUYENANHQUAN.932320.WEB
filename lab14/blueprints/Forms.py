from flask_wtf import FlaskForm
from wtforms import StringField, TextAreaField, BooleanField, RadioField, SelectField as DropDownField, PasswordField, EmailField, IntegerField
from wtforms.validators import DataRequired, Length, Email, EqualTo, NumberRange
import calendar

class TextBoxForm(FlaskForm):
    text = StringField('Text')

class TextAreaForm(FlaskForm):
    text = TextAreaField('Text')

class CheckBoxForm(FlaskForm):
    IsSelected = BooleanField('IsSelected')

class RadioForm(FlaskForm):
    Months = RadioField('Months', choices= [month for month in calendar.month_name if month])

class DropDownForm(FlaskForm):
    Months = DropDownField('Months', choices=[month for month in calendar.month_name if month])

ListBoxField = DropDownField
class ListBoxForm(FlaskForm):
    Months = ListBoxField()


SelectField = ListBoxField
class SignUpForm(FlaskForm):
    firstname = StringField('First name', validators=[DataRequired(), Length(max=100)], render_kw={"required": "required"})
    lastname = StringField('Last name', validators=[DataRequired()], render_kw={"required": "required"})
    day = SelectField('Day', choices=[(str(i), str(i)) for i in range(1, 32)], validators=[DataRequired()])
    month = SelectField('Months', choices=[month for month in calendar.month_name if month], validators=[DataRequired()])
    year = SelectField('Year', choices=[(str(i), str(i)) for i in range(1900, 2026)], validators=[DataRequired()])
    gender = RadioField('Gender', validators=[DataRequired()], choices = [('m', 'Male'),('f', 'Female')], render_kw={"required": "required"})
    email = EmailField('Email', validators=[Email(), DataRequired(), Length(max=100)], render_kw={"required": "required"})
    password =  PasswordField('Password', validators=[DataRequired()], render_kw={"required": "required"})
    confirmpassword = PasswordField('Confirm password', validators=[DataRequired(), EqualTo('password')], render_kw={"required": "required"})


class ResetForm(FlaskForm):
    email = EmailField('Email', validators=[Email(), DataRequired(), Length(max=100)], render_kw={"required": "required"})
    code = IntegerField('Code', validators=[DataRequired()])