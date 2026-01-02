from app import db

class Doctor(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(100), nullable=False)
    specialty = db.Column(db.String(200))

    def __repr__(self):
        return f"<ID {self.id} Doctor {self.name} Specialty {self.specialty}>"