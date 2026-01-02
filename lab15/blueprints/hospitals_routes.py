from flask import Blueprint, request, render_template, redirect, url_for, jsonify
from blueprints.Forms import *
import sqlite3

DB_PATH = 'site.db'

def get_conn():
    conn = sqlite3.connect(DB_PATH)
    conn.row_factory = sqlite3.Row
    return conn

hospital_bp = Blueprint('hospital', __name__)


@hospital_bp.route('/')
def IndexHospital():
    conn = get_conn()
    conn.execute('''CREATE TABLE IF NOT EXISTS hospital (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        name TEXT NOT NULL,
        address TEXT
        phone INTEGER
    )''')
    cur = conn.execute('SELECT id, name, address, phone FROM hospital')
    rows = [dict(r) for r in cur.fetchall()]
    conn.close()
    return render_template('Hospitals/index.html', list=rows)


@hospital_bp.route('/Create', methods=['GET', 'POST'])
def CreateHospital():
    form = HospitalForm()
    if request.method == 'POST':
        name = request.form.get('name')
        address = request.form.get('address')
        phone = request.form.get('phone')
        conn = get_conn()
        conn.execute('INSERT INTO hospital (name,address,phone) VALUES (?,?,?)', (name, address, phone))
        conn.commit()
        conn.close()
        return redirect(url_for('hospital.IndexHospital'))
    return render_template('Hospitals/create.html', form = form)

@hospital_bp.route('/Edit/<int:id>', methods=['GET', 'POST'])
def EditHospital(id):
    conn = get_conn()
    cur = conn.execute('SELECT id,name,address, phone FROM hospital WHERE id=?', (id,))
    row = cur.fetchone()
    conn.close()
    if not row:
        return jsonify({'error': 'not found'}), 404
    return jsonify({'id': row['id'], 'name': row['name'], 'address': row['address'], 'phone': row['phone'], 'MESSAGE':'!!!!!!! PHOTO NOT GIVEN !!!!!!!!'})


@hospital_bp.route('/Details/<int:id>', methods=['GET'])
def DetailsHospital(id):
    conn = get_conn()
    cur = conn.execute('SELECT id,name,address,phone FROM hospital WHERE id=?', (id,))
    row = cur.fetchone()
    conn.close()
    temp = HospitalForm(data=dict(row))
    return render_template('Hospitals/details.html', data = temp)

@hospital_bp.route('/Delete/<int:id>', methods=['POST'])
def DeleteHospital(id):
    conn = get_conn()
    conn.execute('DELETE FROM hospital WHERE id = ?', (id,))
    conn.commit()
    conn.close()
    return redirect(url_for('hospital.IndexHospital'))


