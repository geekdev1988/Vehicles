import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html'
})
export class VehicleComponent {
  public vehicles: Vehicle[];
  public vehicleTypes: any[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Vehicle[]>(baseUrl + 'vehicle').subscribe(result => {
      this.vehicles = result;
    }, error => console.error(error));

    this.vehicleTypes = [
      {
        id: 1, value: 'Car', viewValue: 'Car'
      }
    ];
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
