import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { vehicleCategory} from './../Models/vehicleCategory';
import { Router } from '@angular/router';
@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html'
})
export class VehicleComponent {
  public vehicles: Vehicle[];
  public vehicleTypes: vehicleCategory[];
  public apiUrl: string;
  selectedVehicleType: number;
  constructor(
   private http: HttpClient,
    private router: Router,
    @Inject('BASE_URL')  baseUrl: string) {
    this.apiUrl = baseUrl;
    http.get<vehicleCategory[]>(baseUrl + 'VehicleCategoryMasters').subscribe(result => {      
      this.vehicleTypes = result;         
    }, error => console.error(error));    
  }
  onVehicleSelection(data) {
    
    this.selectedVehicleType = data.value;    
    this.http.get<Vehicle[]>(this.apiUrl + 'api/VehicleDetails/'+ this.selectedVehicleType).subscribe(result => {
      this.vehicles = result;
      console.log(result);
    }, error => console.error(error)); 
  }
  goToCreateVehicle() {
    this.router.navigate(['vehicle/create'], {
      queryParams: { vehicleType: this.selectedVehicleType }
    });
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
