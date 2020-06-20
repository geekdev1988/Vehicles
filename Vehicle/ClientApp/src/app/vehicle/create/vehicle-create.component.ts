import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { vehicleCategory } from './../../Models/vehicleCategory';
import { Router } from '@angular/router';

import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-vehicle-create',
  templateUrl: './vehicle-create.component.html'
})
export class VehicleCreateComponent {
  public vehicles: Vehicle[];
  public vehicleTypes: vehicleCategory[];
  selectedVehicleType: number;
  createVehicleForm;
  private makes: any[];
  private bodyTypes: any[];
  constructor(
    private http: HttpClient,
    private router: Router,
    private formBuilder: FormBuilder,
    @Inject('BASE_URL') private baseUrl: string) {
    http.get<vehicleCategory[]>(baseUrl + 'VehicleCategoryMasters').subscribe(result => {
      this.vehicleTypes = result;
      this.makes = [
        { id: 1, name: 'make1' },
        { id: 2, name: 'make2' }
      ];
      this.bodyTypes = [
        { id: 1, name: 'HatchBack' },
        { id: 2, name: 'Sedan' }
      ];
      console.log(this.vehicleTypes);
    }, error => console.error(error));

    this.createVehicleForm = this.formBuilder.group({
      vehicleType: 1,
      make: 1,
      model: '',
      engine: '',
      doors: '',
      wheels: '',
      bodyType: ''
    });
  }
  onVehicleSelection(data) {
    this.selectedVehicleType = data.value;
    console.log('success' + data.value);
  }
  goToCreateVehicle() {
    this.router.navigate(['/vehicle/create'], {
      queryParams: { vehicleType: this.selectedVehicleType }
    });
  }
  onSubmit(vehicleData) {
    debugger;
    this.http.post(this.baseUrl + 'api/VehicleDetails', vehicleData).subscribe(result => {
      this.createVehicleForm.reset();
      console.log(this.vehicleTypes);
    }, error => console.error(error));
    console.warn('Your Vehicle has been created', vehicleData);
  }
}

interface Vehicle {
  id: string;
  make: number;
  model: number;
  engine: string;
  doors: number;
  wheels: number;
  vehicleTypeId: number;
  bodyTypeId: number;
}
