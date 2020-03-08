package me.yuri.checksumgen;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Scanner;

public class Checksum {

    public static void main(String[] b){
        start();
    }

    private static Scanner sc = new Scanner(System.in);
    private static MessageDigest md;
    private static boolean text = false;
    private static String tx;
    private static void start() {
        System.out.println("Choose your algorithm:");
        String fn = sc.nextLine();
        if(fn.equalsIgnoreCase("!exit")){
            System.exit(0);
            return;
        }
        try {
            md = MessageDigest.getInstance(fn);
        } catch (NoSuchAlgorithmException e) {
            System.out.println("Algorithm " + fn +" does not exist! Please select a valid algorithm or type !exit to exit...");
            start();
            return;
        }
        System.out.println("Algorithm selected: " + fn+"!");
        selecc();
    }

    private static void selecc() {
        System.out.println("Select your file or add =t to calculate checksum for text: ");
        String f = sc.nextLine();
        if(f.endsWith("=t")){
            text = true;
            tx = f.substring(0, f.length()-2);
        } else tx= f;
        if(f.equalsIgnoreCase("!exit")){
            System.exit(0);
            return;
        }
        File ff = new File(tx);
        if(!ff.exists() && !text){
            System.out.println("File " + f + " does not exist! Please type in the path of an existing file or type !exit to exit...");
            selecc();
            return;
        }
        System.out.println("Selected "+(!text ? "file" : "text")+": " + tx+"!");
        System.out.println("Press any key to continue...");
        sc.nextLine();
        System.out.println();
        System.out.println();
        System.out.println("Checksum (" + md.getAlgorithm()+"): "+cc());
        System.out.println();
        System.out.println();
        System.out.println("Press any key to continue...");
        sc.nextLine();
    }

    private static String cc()
    {
        File f = new File(tx);
        if(!f.exists() && !text){
            return "File " + f.getName() +" not found!";
        }
            try {
                if(!text) {
                    FileInputStream fis = new FileInputStream(f);
                    byte[] bb = new byte[1024];
                    int bc = 0;
                    while ((bc = fis.read(bb)) != -1) {
                        md.update(bb, 0, bc);
                    }
                    fis.close();
                } else {
                    byte[] bb = tx.getBytes();
                    md.update(bb);
                }

                byte[] bbb = md.digest();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bbb.length; i++) {
                    sb.append(Integer.toString((bbb[i] & 0xff) + 0x100, 16).substring(1));
                }
                return sb.toString();
            } catch (IOException e) {
                return e.getMessage();
            }

    }

}
