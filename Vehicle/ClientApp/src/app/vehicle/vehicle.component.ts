import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { vehicleCategory} from './../Models/vehicleCategory';
@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html'
})
export class VehicleComponent {
  public vehicles: Vehicle[];
  public vehicleTypes: vehicleCategory[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<vehicleCategory[]>(baseUrl + 'VehicleCategoryMasters').subscribe(result => {
      this.vehicleTypes = result;
      console.log(this.vehicleTypes);      
    }, error => console.error(error));    
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
