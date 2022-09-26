import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

import { Cagri } from '../models/Cagri';
import { CagriService } from '../services/cagri.service';

@Component({
  selector: 'app-kayitlar',
  templateUrl: './kayitlar.component.html',
  styleUrls: ['./kayitlar.component.css']
})
export class KayitlarComponent implements OnInit {

  kayitListe: Cagri[] = []
  aktifCagri: Cagri = new Cagri();
  musteriAdi: string = '';
  //editMode: Boolean = false;
  cagriId: string;
  @ViewChild('cagriForm') form: NgForm

  constructor(private webApiSvc: CagriService) { }

  ngOnInit(): void {
    this.KayitlariOku();
  }

  search() {
    if (this.musteriAdi != "") {
      this.kayitListe = this.kayitListe.filter(res => {
        return res.musteriAdi.toLocaleLowerCase().match(this.musteriAdi.toLocaleLowerCase());
      })
    }
    else if (this.musteriAdi == "") {
      this.ngOnInit();
    }
  }

  KayitlariOku() {
    this.webApiSvc.getCagriDetay().subscribe((data: Cagri[]) => {
      this.kayitListe = data;
    });
  }

  ekraniTemizle(){
    this.aktifCagri.id = 0;
    this.aktifCagri.musteriAdi = '';
    this.aktifCagri.konu = '';
    this.aktifCagri.aciklama = '';
    this.aktifCagri.durum = '';
    this.aktifCagri.sonuc = '';
    this.aktifCagri.servisElemani = '';
    this.aktifCagri.cagriTarihi = '';
    this.cagriModelToForm();
  }

  formToCagriModel(myFormData: any){
    //this.aktifCagri.id = myFormData.id
    this.aktifCagri.musteriAdi = myFormData.musteriAdi
    this.aktifCagri.konu = myFormData.konu
    this.aktifCagri.aciklama = myFormData.aciklama;
    this.aktifCagri.durum = myFormData.durum;
    this.aktifCagri.sonuc = myFormData.sonuc;
    this.aktifCagri.servisElemani = myFormData.servisElemani;
    this.aktifCagri.cagriTarihi = myFormData.cagriTarihi;  
  }

  cagriKaydet(myFormData: any) {
    this.formToCagriModel(myFormData)      
    if (this.aktifCagri.id > 0) {
      console.log(myFormData);
      //let aCagri: Cagri = new Cagri();
      this.webApiSvc.postCagriDetay(this.aktifCagri).subscribe(data => {
        console.log(data);
      })
    }
    else {
      //let aCagri: Cagri = new Cagri();
      this.webApiSvc.updateCagriDetay(this.aktifCagri.id, this.aktifCagri)
    }
  }

  cagriSil(item: any) {
    this.webApiSvc.deleteCagriDetay(item).subscribe((result) => {
      console.warn("result", result)
    });
  }

  cagriGuncelle(item: Cagri) {
    Object.assign(this.aktifCagri, item);
    this.cagriModelToForm();
  }

  cagriModelToForm(){
    this.form.setValue({
      musteriAdi: this.aktifCagri.musteriAdi,
      cagriTarihi: this.aktifCagri.cagriTarihi,
      servisElemani: this.aktifCagri.servisElemani,
      konu: this.aktifCagri.konu,
      aciklama: this.aktifCagri.aciklama,
      durum: this.aktifCagri.durum,
      sonuc: this.aktifCagri.sonuc
    });
  }


}
