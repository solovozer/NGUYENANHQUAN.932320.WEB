from flask import Blueprint, request, render_template, redirect, url_for, jsonify
from blueprints.Forms import *
import sqlite3


DB_PATH = 'site.db'

def get_conn():
    conn = sqlite3.connect(DB_PATH)
    conn.row_factory = sqlite3.Row
    return conn

patient_bp = Blueprint('patient', __name__)

@patient_bp.route('/')
def IndexPatient():
    return render_template('Patients/index.html')
    
