from flask import Blueprint, request, render_template, redirect, url_for, jsonify
from blueprints.Forms import *
import sqlite3

DB_PATH = 'site.db'

def get_conn():
    conn = sqlite3.connect(DB_PATH)
    conn.row_factory = sqlite3.Row
    return conn

doctor_bp = Blueprint('doctor', __name__)


@doctor_bp.route('/')
def IndexDoctor():
    conn = get_conn()
    conn.execute('''CREATE TABLE IF NOT EXISTS doctor (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        name TEXT NOT NULL,
        specialty TEXT
    )''')
    cur = conn.execute('SELECT id, name, specialty FROM doctor')
    rows = [dict(r) for r in cur.fetchall()]
    conn.close()
    return render_template('Doctors/index.html', list=rows)


@doctor_bp.route('/Create', methods=['GET', 'POST'])
def CreateDoctor():
    form = DoctorForm()
    if request.method == 'POST':
        name = request.form.get('name')
        specialty = request.form.get('specialty')
        conn = get_conn()
        conn.execute('INSERT INTO doctor (name,specialty) VALUES (?,?)', (name, specialty))
        conn.commit()
        conn.close()
        return redirect(url_for('doctor.IndexDoctor'))
    return render_template('Doctors/create.html', form = form)

@doctor_bp.route('/Edit/<int:id>', methods=['GET', 'POST'])
def EditDoctor(id):
    conn = get_conn()
    cur = conn.execute('SELECT id,name,specialty FROM doctor WHERE id=?', (id,))
    row = cur.fetchone()
    conn.close()
    if not row:
        return jsonify({'error': 'not found'}), 404
    return jsonify({'id': row['id'], 'name': row['name'], 'specialty': row['specialty'], 'MESSAGE':'!!!!!!! PHOTO NOT GIVEN !!!!!!!!'})


@doctor_bp.route('/Details/<int:id>', methods=['GET'])
def DetailsDoctor(id):
    conn = get_conn()
    cur = conn.execute('SELECT id,name,specialty FROM doctor WHERE id=?', (id,))
    row = cur.fetchone()
    conn.close()
    temp = DoctorForm(data=dict(row))
    return render_template('Doctors/details.html', data = temp)

@doctor_bp.route('/Delete/<int:id>', methods=['POST'])
def DeleteDoctor(id):
    conn = get_conn()
    conn.execute('DELETE FROM doctor WHERE id = ?', (id,))
    conn.commit()
    conn.close()
    return redirect(url_for('doctor.IndexDoctor'))


